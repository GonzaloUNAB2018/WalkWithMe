<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exportacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dg_data = New System.Windows.Forms.DataGridView()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.bar_progreso = New System.Windows.Forms.ProgressBar()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btn_ruta = New System.Windows.Forms.Button()
        Me.lbl_ruta = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.dg_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_data
        '
        Me.dg_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_data.Location = New System.Drawing.Point(4, 4)
        Me.dg_data.Name = "dg_data"
        Me.dg_data.Size = New System.Drawing.Size(1427, 474)
        Me.dg_data.TabIndex = 0
        '
        'btn_exportar
        '
        Me.btn_exportar.Location = New System.Drawing.Point(288, 19)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(93, 23)
        Me.btn_exportar.TabIndex = 1
        Me.btn_exportar.Text = "Exportar Data"
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'bar_progreso
        '
        Me.bar_progreso.Location = New System.Drawing.Point(6, 19)
        Me.bar_progreso.Name = "bar_progreso"
        Me.bar_progreso.Size = New System.Drawing.Size(276, 23)
        Me.bar_progreso.TabIndex = 2
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(3, 45)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(61, 13)
        Me.lbl_total.TabIndex = 3
        Me.lbl_total.Text = "cargando..."
        Me.lbl_total.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "Ergosana"
        Me.OpenFileDialog1.Filter = "Base de Datos Access |*.mdb"
        '
        'btn_ruta
        '
        Me.btn_ruta.Location = New System.Drawing.Point(6, 28)
        Me.btn_ruta.Name = "btn_ruta"
        Me.btn_ruta.Size = New System.Drawing.Size(105, 23)
        Me.btn_ruta.TabIndex = 4
        Me.btn_ruta.Text = "Abrir Base Datos"
        Me.btn_ruta.UseVisualStyleBackColor = True
        '
        'lbl_ruta
        '
        Me.lbl_ruta.AutoSize = True
        Me.lbl_ruta.Location = New System.Drawing.Point(3, 12)
        Me.lbl_ruta.Name = "lbl_ruta"
        Me.lbl_ruta.Size = New System.Drawing.Size(25, 13)
        Me.lbl_ruta.TabIndex = 5
        Me.lbl_ruta.Text = "ruta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bar_progreso)
        Me.GroupBox1.Controls.Add(Me.btn_exportar)
        Me.GroupBox1.Controls.Add(Me.lbl_total)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 541)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 61)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_ruta)
        Me.GroupBox2.Controls.Add(Me.lbl_ruta)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 484)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(387, 57)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Exportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1435, 606)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_data)
        Me.Name = "Exportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportación de datos"
        CType(Me.dg_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dg_data As DataGridView
    Friend WithEvents btn_exportar As Button
    Friend WithEvents bar_progreso As ProgressBar
    Friend WithEvents lbl_total As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btn_ruta As Button
    Friend WithEvents lbl_ruta As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
