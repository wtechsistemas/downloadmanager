Imports System.IO
Imports System.Net
Imports System.Xml

Public Class Form1
    Private settingsFilePath As String = "settings.xml"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar o ListView como exibição de tabela
        ListView1.View = View.Details

        ' Adicionar as colunas ao ListView
        ListView1.Columns.Add("URL", 200)
        ListView1.Columns.Add("Nome do Arquivo", 160)
        ListView1.Columns.Add("Tamanho", 80)
        ListView1.Columns.Add("Status", 80)

        ' Carregar as configurações do arquivo XML, se existir
        LoadSettingsFromFile()

        ' Habilitar o botão Cancelar
        Buttoncancelar.Enabled = False

        ' Habilitar a capacidade de arrastar e soltar arquivos no ListView
        ListView1.AllowDrop = True
        AddHandler ListView1.DragEnter, AddressOf ListView1_DragEnter
        AddHandler ListView1.DragDrop, AddressOf ListView1_DragDrop
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Salvar as configurações no arquivo XML
        SaveSettingsToFile()
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        ' Obter a URL do vídeo
        Dim url As String = TextURL.Text

        ' Obter o nome do arquivo a partir da URL
        Dim fileName As String = Path.GetFileName(url)

        ' Obter o tamanho do arquivo
        Dim fileSize As String = GetFileSize(url)

        ' Definir o ícone com base na extensão do arquivo
        Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
        Dim imageIndex As Integer
        Select Case fileExtension
            Case ".exe"
                imageIndex = 0
            Case ".zip", ".rar", ".iso"
                imageIndex = 1
            Case ".jpg", ".bmp", ".png", ".gif"
                imageIndex = 2
            Case Else
                imageIndex = 3
        End Select

        ' Adicionar o link, nome do arquivo, tamanho e status ao ListView
        Dim item As New ListViewItem({url, fileName, fileSize, "Aguardando"})
        item.ImageIndex = imageIndex

        ListView1.Items.Add(item)
    End Sub

    Private Function GetFileSize(url As String) As String
        Try
            Using webClient As New WebClient()
                Dim fileInfo = webClient.OpenRead(url)
                Dim sizeInBytes = Convert.ToInt64(webClient.ResponseHeaders("Content-Length"))
                Dim sizeInMB = Math.Round(sizeInBytes / (1024.0 * 1024.0), 2)
                Return $"{sizeInMB} MB"
            End Using
        Catch ex As Exception
            Return "N/A"
        End Try
    End Function

    Private Sub ButtonPasta_Click(sender As Object, e As EventArgs) Handles Buttonpasta.Click
        ' Abrir o diálogo de seleção de pasta
        Dim dialog As New FolderBrowserDialog()
        If dialog.ShowDialog() = DialogResult.OK Then
            textboxdestino.Text = dialog.SelectedPath
        End If
    End Sub

    Private Sub ButtonRemover_Click(sender As Object, e As EventArgs) Handles Buttonremover.Click
        ' Remover o item selecionado do ListView
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.Items.Remove(ListView1.SelectedItems(0))
        End If
    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles Buttoncancelar.Click
        ' Cancelar os downloads
        For Each item As ListViewItem In ListView1.Items
            If item.Tag IsNot Nothing AndAlso TypeOf item.Tag Is WebClient Then
                DirectCast(item.Tag, WebClient).CancelAsync()
            End If
        Next

        ' Habilitar o botão Iniciar novamente
        Buttoniniciar.Enabled = True

        ' Desabilitar o botão Cancelar
        Buttoncancelar.Enabled = False
    End Sub

    Private Sub ButtonIniciar_Click(sender As Object, e As EventArgs) Handles Buttoniniciar.Click
        ' Desabilitar o botão Iniciar
        Buttoniniciar.Enabled = False

        ' Habilitar o botão Cancelar
        Buttoncancelar.Enabled = True

        ' Iniciar os downloads
        For Each item As ListViewItem In ListView1.Items
            If item.Tag Is Nothing Then
                Dim url As String = item.SubItems(0).Text
                Dim fileName As String = item.SubItems(1).Text
                Dim destinationPath As String = Path.Combine(textboxdestino.Text, fileName)

                Dim webClient As New WebClient()
                AddHandler webClient.DownloadProgressChanged, AddressOf WebClient_DownloadProgressChanged
                AddHandler webClient.DownloadFileCompleted, AddressOf WebClient_DownloadFileCompleted

                webClient.DownloadFileAsync(New Uri(url), destinationPath, item)

                item.Tag = webClient
            End If
        Next
    End Sub

    Private Sub WebClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim webClient As WebClient = DirectCast(sender, WebClient)
        Dim item As ListViewItem = DirectCast(e.UserState, ListViewItem)

        ' Atualizar a ProgressBar
        item.SubItems(3).Text = "Baixando"
        ProgressBar1.Value = e.ProgressPercentage

        ' Atualizar o status do download
        Dim downloadedSize = Math.Round(e.BytesReceived / (1024.0 * 1024.0), 2)
        Dim totalSize = Math.Round(e.TotalBytesToReceive / (1024.0 * 1024.0), 2)
        Dim speed = Math.Round(e.BytesReceived / (1024.0 * e.ProgressPercentage / 100), 2)
        StatusLabel.Text = $"Baixando o arquivo {ListView1.Items.IndexOf(item) + 1} de {ListView1.Items.Count} ({downloadedSize} MB de {totalSize} MB, Velocidade: {speed} KB/s)"

        ' Atualizar o ícone para o ícone em andamento (índice 3) do ImageList
        item.ImageIndex = 4
    End Sub

    Private Sub WebClient_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim webClient As WebClient = DirectCast(sender, WebClient)
        Dim item As ListViewItem = DirectCast(e.UserState, ListViewItem)

        ' Verificar se o download foi concluído com sucesso
        If e.Error Is Nothing AndAlso Not e.Cancelled Then
            ' Atualizar o status do download
            item.SubItems(3).Text = "Concluído"

            ' Atualizar o ícone para o ícone de conclusão (índice 5) do ImageList
            item.ImageIndex = 5
        Else
            ' Atualizar o status do download
            item.SubItems(3).Text = "Erro"

            ' Atualizar o ícone para o ícone de erro (índice 6) do ImageList
            item.ImageIndex = 6
        End If

        ' Remover o WebClient associado ao item
        item.Tag = Nothing

        ' Verificar se todos os downloads foram concluídos
        If ListView1.Items.Cast(Of ListViewItem)().All(Function(i) i.SubItems(3).Text <> "Baixando") Then
            ' Habilitar o botão Iniciar novamente
            Buttoniniciar.Enabled = True

            ' Desabilitar o botão Cancelar
            Buttoncancelar.Enabled = False

            ' Exibir mensagem de conclusão
            MessageBox.Show("Todos os downloads foram concluídos.")
        End If
    End Sub

    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs)
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        For Each file In files
            If Path.GetExtension(file).ToLower() = ".txt" Then
                Dim urls As List(Of String) = GetUrlsFromFile(file)

                For Each url In urls
                    Dim fileName As String = Path.GetFileName(url)
                    Dim fileSize As String = GetFileSize(url)
                    Dim imageIndex As Integer = 3 ' Índice do ícone padrão

                    Dim item As New ListViewItem({url, fileName, fileSize, "Aguardando"})
                    item.ImageIndex = imageIndex

                    ListView1.Items.Add(item)
                Next
            End If
        Next
    End Sub

    Private Function GetUrlsFromFile(filePath As String) As List(Of String)
        Dim urls As New List(Of String)()

        Try
            Using reader As New StreamReader(filePath)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine().Trim()

                    If line.StartsWith("http://") OrElse line.StartsWith("https://") Then
                        urls.Add(line)
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao ler o arquivo de texto: " & ex.Message)
        End Try

        Return urls
    End Function

    Private Sub LoadSettingsFromFile()
        If File.Exists(settingsFilePath) Then
            Try
                Dim doc As New XmlDocument()
                doc.Load(settingsFilePath)

                textboxdestino.Text = doc.SelectSingleNode("/settings/destinationFolder")?.InnerText
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar as configurações do arquivo XML: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub SaveSettingsToFile()
        Try
            Dim doc As New XmlDocument()
            Dim rootElement As XmlElement = doc.CreateElement("settings")
            doc.AppendChild(rootElement)

            Dim destinationFolderElement As XmlElement = doc.CreateElement("destinationFolder")
            destinationFolderElement.InnerText = textboxdestino.Text
            rootElement.AppendChild(destinationFolderElement)

            doc.Save(settingsFilePath)
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar as configurações no arquivo XML: " & ex.Message)
        End Try
    End Sub
End Class
