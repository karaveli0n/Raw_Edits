// Decompiled with JetBrains decompiler
// Type: Raw_Edits.Form2
// Assembly: Raw Edits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6B593637-1E45-4A27-9C29-8DFE79046505
// Assembly location: C:\Program Files (x86)\FDStudios\RawEdits\Raw Edits.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Raw_Edits
{
  public class Form2 : Form
  {
    private int selectX;
    private int selectY;
    private int selectWidth;
    private int selectHeight;
    public Pen selectPen;
    private bool start = false;
    public int ff;
    public int vv;
    private IContainer components = (IContainer) null;
    private PictureBox pictureBox2;

    public Form2() => this.InitializeComponent();

    private void SaveToClipBoard()
    {
      Form1 form1 = new Form1();
      Form2 form2 = new Form2();
      if (this.selectWidth > 0)
      {
        Rectangle srcRect = new Rectangle(this.selectX, this.selectY, this.selectWidth, this.selectHeight);
        Bitmap bitmap1 = new Bitmap(this.pictureBox2.Image, this.pictureBox2.Width, this.pictureBox2.Height);
        Bitmap bitmap2 = new Bitmap(this.selectWidth, this.selectHeight);
        Graphics graphics = Graphics.FromImage((Image) bitmap2);
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.DrawImage((Image) bitmap1, 0, 0, srcRect, GraphicsUnit.Pixel);
        Clipboard.SetImage((Image) bitmap2);
      }
      this.Close();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      this.Hide();
      Rectangle bounds = Screen.PrimaryScreen.Bounds;
      int width = bounds.Width;
      bounds = Screen.PrimaryScreen.Bounds;
      int height = bounds.Height;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics.FromImage((Image) bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        bitmap.Save((Stream) memoryStream, ImageFormat.Bmp);
        this.pictureBox2.Size = new Size(this.Width, this.Height);
        this.pictureBox2.Image = Image.FromStream((Stream) memoryStream);
      }
      this.Show();
      this.Cursor = Cursors.Cross;
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.pictureBox2.Image == null || !this.start)
        return;
      this.pictureBox2.Refresh();
      this.selectWidth = e.X - this.selectX;
      this.selectHeight = e.Y - this.selectY;
      this.pictureBox2.CreateGraphics().DrawRectangle(this.selectPen, this.selectX, this.selectY, this.selectWidth, this.selectHeight);
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (!this.start)
      {
        if (e.Button == MouseButtons.Left)
        {
          this.selectX = e.X;
          this.selectY = e.Y;
          this.selectPen = new Pen(Color.Red, 1f);
          this.selectPen.DashStyle = DashStyle.DashDotDot;
        }
        this.pictureBox2.Refresh();
        this.start = true;
      }
      else
      {
        if (this.pictureBox2.Image == null)
          return;
        if (e.Button == MouseButtons.Left)
        {
          this.pictureBox2.Refresh();
          this.selectWidth = e.X - this.selectX;
          this.selectHeight = e.Y - this.selectY;
          this.pictureBox2.CreateGraphics().DrawRectangle(this.selectPen, this.selectX, this.selectY, this.selectWidth, this.selectHeight);
        }
        this.start = false;
        this.SaveToClipBoard();
      }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pictureBox2 = new PictureBox();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.pictureBox2.BackColor = Color.Black;
      this.pictureBox2.Location = new Point(0, 0);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(449, 414);
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox2.MouseDown += new MouseEventHandler(this.pictureBox1_MouseDown);
      this.pictureBox2.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(461, 426);
      this.Controls.Add((Control) this.pictureBox2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Form2);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Form2);
      this.TransparencyKey = SystemColors.Control;
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.Form2_Load);
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
    }
  }
}
