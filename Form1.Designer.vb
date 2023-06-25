<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        Buttoniniciar = New Button()
        TextURL = New TextBox()
        ProgressBar1 = New ProgressBar()
        textboxdestino = New TextBox()
        ButtonAdd = New Button()
        ListView1 = New ListView()
        ImageList1 = New ImageList(components)
        Buttoncancelar = New Button()
        Buttonremover = New Button()
        Buttonpasta = New Button()
        StatusLabel = New Label()
        Buttonadicionar = New Button()
        SuspendLayout()
        ' 
        ' Buttoniniciar
        ' 
        Buttoniniciar.Location = New Point(38, 365)
        Buttoniniciar.Name = "Buttoniniciar"
        Buttoniniciar.Size = New Size(91, 58)
        Buttoniniciar.TabIndex = 0
        Buttoniniciar.Text = "Iniciar"
        Buttoniniciar.UseVisualStyleBackColor = True
        ' 
        ' TextURL
        ' 
        TextURL.Location = New Point(12, 12)
        TextURL.Name = "TextURL"
        TextURL.Size = New Size(619, 23)
        TextURL.TabIndex = 1
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(232, 365)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(399, 23)
        ProgressBar1.TabIndex = 2
        ' 
        ' textboxdestino
        ' 
        textboxdestino.Location = New Point(12, 42)
        textboxdestino.Name = "textboxdestino"
        textboxdestino.Size = New Size(619, 23)
        textboxdestino.TabIndex = 3
        ' 
        ' ButtonAdd
        ' 
        ButtonAdd.Location = New Point(637, 12)
        ButtonAdd.Name = "ButtonAdd"
        ButtonAdd.Size = New Size(33, 23)
        ButtonAdd.TabIndex = 4
        ButtonAdd.Text = "+"
        ButtonAdd.UseVisualStyleBackColor = True
        ' 
        ' ListView1
        ' 
        ListView1.LargeImageList = ImageList1
        ListView1.Location = New Point(12, 84)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(619, 248)
        ListView1.SmallImageList = ImageList1
        ListView1.TabIndex = 5
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth8Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "3876348_exe_executable_extension_file_icon.ico")
        ImageList1.Images.SetKeyName(1, "3876325_compressed_extension_file_z_icon.ico")
        ImageList1.Images.SetKeyName(2, "1608474_file_o_picture_icon.ico")
        ImageList1.Images.SetKeyName(3, "7267725_ext_file_generic_icon.ico")
        ImageList1.Images.SetKeyName(4, "4634457_interface_loading_sand_sandwatch_waiting_icon.ico")
        ImageList1.Images.SetKeyName(5, "9044028_checkbox_checked_filled_icon.ico")
        ' 
        ' Buttoncancelar
        ' 
        Buttoncancelar.Location = New Point(135, 365)
        Buttoncancelar.Name = "Buttoncancelar"
        Buttoncancelar.Size = New Size(91, 58)
        Buttoncancelar.TabIndex = 6
        Buttoncancelar.Text = "Cancelar"
        Buttoncancelar.UseVisualStyleBackColor = True
        ' 
        ' Buttonremover
        ' 
        Buttonremover.Location = New Point(636, 88)
        Buttonremover.Name = "Buttonremover"
        Buttonremover.Size = New Size(34, 23)
        Buttonremover.TabIndex = 7
        Buttonremover.Text = "X"
        Buttonremover.UseVisualStyleBackColor = True
        ' 
        ' Buttonpasta
        ' 
        Buttonpasta.Location = New Point(637, 44)
        Buttonpasta.Name = "Buttonpasta"
        Buttonpasta.Size = New Size(33, 21)
        Buttonpasta.TabIndex = 8
        Buttonpasta.Text = "..."
        Buttonpasta.UseVisualStyleBackColor = True
        ' 
        ' StatusLabel
        ' 
        StatusLabel.AutoSize = True
        StatusLabel.Location = New Point(235, 402)
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(41, 15)
        StatusLabel.TabIndex = 9
        StatusLabel.Text = "Label1"
        ' 
        ' Buttonadicionar
        ' 
        Buttonadicionar.Location = New Point(638, 123)
        Buttonadicionar.Name = "Buttonadicionar"
        Buttonadicionar.Size = New Size(40, 86)
        Buttonadicionar.TabIndex = 10
        Buttonadicionar.Text = "Button1"
        Buttonadicionar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(690, 450)
        Controls.Add(Buttonadicionar)
        Controls.Add(StatusLabel)
        Controls.Add(Buttonpasta)
        Controls.Add(Buttonremover)
        Controls.Add(Buttoncancelar)
        Controls.Add(ListView1)
        Controls.Add(ButtonAdd)
        Controls.Add(textboxdestino)
        Controls.Add(ProgressBar1)
        Controls.Add(TextURL)
        Controls.Add(Buttoniniciar)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Buttoniniciar As Button
    Friend WithEvents TextURL As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents textboxdestino As TextBox
    Friend WithEvents ButtonAdd As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Buttoncancelar As Button
    Friend WithEvents Buttonremover As Button
    Friend WithEvents Buttonpasta As Button
    Friend WithEvents StatusLabel As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Buttonadicionar As Button
End Class
