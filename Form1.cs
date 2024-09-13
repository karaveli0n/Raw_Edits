using CefSharp;
using CefSharp.WinForms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;

#nullable disable
namespace Raw_Edits
{
  public class Form1 : Form
  {
    private ChromiumWebBrowser chrome;
    private ChromiumWebBrowser chrome23c;
    private IFirebaseClient ss;
    private IFirebaseConfig ifc = (IFirebaseConfig) new FirebaseConfig()
    {
      AuthSecret = "Buraya_Api_Yaz",
      BasePath = "https://rawedit-c56a4.firebaseio.com/"
    };
    private string ggarmy;
    private Form2 frm2;
    private ChromiumWebBrowser chrome222;
    private IContainer components = (IContainer) null;
    private Button button1;
    private PictureBox pictureBox1;
    private RichTextBox richTextBox1;
    private ComboBox comboBox1;
    private ComboBox comboBox2;
    private ListBox listBox1;
    private Button button2;
    private Button button3;
    private Timer timer1;
    private LinkLabel linkLabel1;
    private Panel panel3;
    private Timer timer2;
    private Panel panel2;
    private Panel panel1;
    private Button button4;

    public Form1()
    {
      this.InitializeComponent();
      this.KeyPreview = true;
    }

    public void cc()
    {
      try
      {
        int index1 = 0;
        this.ss = (IFirebaseClient) new FirebaseClient(this.ifc);
        ppp ppp = this.ss.Get("promo/" + "xxxx").ResultAs<ppp>();
        string sss = ppp.sss;
        this.ggarmy = ppp.vvv;
        string str = sss;
        char[] chArray = new char[2]{ '-', '"' };
        foreach (object obj in str.Split(chArray))
          this.listBox1.Items.Add(obj);
        int count = this.listBox1.Items.Count;
        int[] numArray = new int[count];
        Random random = new Random();
        for (; index1 < 1; ++index1)
        {
          int index2 = random.Next(0, count);
          numArray[index1] = index2;
          string address = this.listBox1.Items[index2]?.ToString() ?? "";
          Cef.Initialize((CefSettingsBase) new CefSettings());
          this.chrome = new ChromiumWebBrowser(address);
          this.panel1.Controls.Add((Control) this.chrome);
          this.chrome.Dock = DockStyle.Fill;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Check Your Internet");
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.timer1.Start();
      this.timer2.Start();
      this.button2.Visible = true;
      this.button3.Visible = false;
      this.listBox1.Visible = false;
      this.cc();
      this.panel3.Visible = false;
      this.comboBox1.Items.Add((object) "en");
      this.comboBox1.Items.Add((object) "tr");
      this.comboBox1.Items.Add((object) "ko");
      this.comboBox1.Items.Add((object) "fr");
      this.comboBox1.Items.Add((object) "ja");
      this.comboBox1.Items.Add((object) "zh-CN");
      this.comboBox1.Items.Add((object) "ar");
      this.comboBox2.Items.Add((object) "en");
      this.comboBox2.Items.Add((object) "tr");
      this.comboBox2.Items.Add((object) "ko");
      this.comboBox2.Items.Add((object) "fr");
      this.comboBox2.Items.Add((object) "ja");
      this.comboBox2.Items.Add((object) "zh-CN");
      this.comboBox2.Items.Add((object) "ar");
      this.chrome23c = new ChromiumWebBrowser("https://translate.google.com.tr/#tr/en/" + this.richTextBox1.Text + ")");
      this.panel2.Controls.Add((Control) this.chrome23c);
      this.chrome23c.Dock = DockStyle.Fill;
      int num = (int) MessageBox.Show("Programla İlgili Herhangi Bir Sorun Yaşıyor İseniz. Özür Dilerim Bu Programın İlk Sürümüdür Eğer Destek Bölümünden Reklamlara Tıklayıp Yardım Ederseniz İleride(Çook Yakın Bir Zamanda) Sizin İçin daha Harika İşler Çıkartıcağımızdan Emin Olabilirsiniz");
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (Control.ModifierKeys == Keys.Shift)
      {
        this.panel3.Visible = false;
        this.panel2.Visible = false;
        this.listBox1.Visible = false;
        this.comboBox1.Visible = false;
        this.comboBox2.Visible = false;
        this.button1.Visible = false;
        this.button3.Visible = false;
        this.richTextBox1.Visible = false;
        this.ret();
        this.button1.Visible = true;
        this.linkLabel1.Visible = true;
        this.comboBox1.Visible = true;
        this.panel2.Visible = true;
        this.comboBox2.Visible = true;
        this.richTextBox1.Visible = true;
      }
      if (Control.ModifierKeys == Keys.Control)
      {
        this.ff();
        this.translate();
      }
      if (Control.ModifierKeys != Keys.Alt)
        return;
      this.kkff();
      this.translate();
    }

    public void ff()
    {
      try
      {
        this.pictureBox1.Image = Clipboard.GetImage();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Shifte Bas Ve Metin Bulunan Alanı Seç");
      }
      try
      {
        Bitmap image = new Bitmap(Clipboard.GetImage());
        string text = this.comboBox1.Text;
        if (text == null)
          return;
        // ISSUE: reference to a compiler-generated method
        switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(text))
        {
          case 637978675:
            if (!(text == "zh-CN"))
              break;
            this.richTextBox1.Text = new TesseractEngine("./tessdatachi", "chi_sim").Process(image).GetText();
            string[] strArray1 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray1.Length; ++index)
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + strArray1[index] + " ";
            }
            break;
          case 1092248970:
            if (!(text == "en"))
              break;
            this.richTextBox1.Text = new TesseractEngine(Application.StartupPath + "\\tessdata", "eng").Process(image).GetText();
            string[] strArray2 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray2.Length; ++index)
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + strArray2[index] + " ";
            }
            break;
          case 1111292255:
            if (!(text == "ko"))
              break;
            this.richTextBox1.Text = new TesseractEngine("./tessdatakor", "kor").Process(image).GetText();
            string[] strArray3 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray3.Length; ++index)
              this.richTextBox1.Text += strArray3[index];
            break;
          case 1195724803:
            if (!(text == "tr"))
              break;
            this.richTextBox1.Text = new TesseractEngine("./tessdatatur", "tur").Process(image).GetText();
            string[] strArray4 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray4.Length; ++index)
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + strArray4[index] + " ";
            }
            break;
          case 1461901041:
            if (!(text == "fr"))
              break;
            this.richTextBox1.Text = new TesseractEngine("./tessdatafra", "fra").Process(image).GetText();
            string[] strArray5 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray5.Length; ++index)
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + strArray5[index] + " ";
            }
            break;
          case 1562713850:
            if (!(text == "ar"))
              break;
            this.richTextBox1.Text = new TesseractEngine("./tessdataara", "ara").Process(image).GetText();
            string[] strArray6 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray6.Length; ++index)
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + strArray6[index] + " ";
            }
            break;
          case 1816099348:
            if (!(text == "ja"))
              break;
            this.richTextBox1.Text = new TesseractEngine("./tessdatajap", "jpn").Process(image).GetText();
            string[] strArray7 = this.richTextBox1.Text.Split('\n', '|', '-', ',', '"', '/');
            this.richTextBox1.Clear();
            for (int index = 0; index < strArray7.Length; ++index)
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + strArray7[index] + " ";
            }
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void kkff()
    {
      try
      {
        this.pictureBox1.Image = Clipboard.GetImage();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Shifte Bas Ve Metin Bulunan Alanı Seç");
      }
      try
      {
        Bitmap image = new Bitmap(Clipboard.GetImage());
        string text1 = this.comboBox1.Text;
        if (text1 == null)
          return;
        // ISSUE: reference to a compiler-generated method
        switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(text1))
        {
          case 637978675:
            if (!(text1 == "zh-CN"))
              break;
            string text2 = new TesseractEngine("./tessdatachi", "chi_sim").Process(image).GetText();
            char[] chArray1 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text2.Split(chArray1))
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + str + " ";
            }
            break;
          case 1092248970:
            if (!(text1 == "en"))
              break;
            string text3 = new TesseractEngine("./tessdata", "eng").Process(image).GetText();
            char[] chArray2 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text3.Split(chArray2))
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + str + " ";
            }
            break;
          case 1111292255:
            if (!(text1 == "ko"))
              break;
            string text4 = new TesseractEngine("./tessdatakor", "kor").Process(image).GetText();
            char[] chArray3 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text4.Split(chArray3))
              this.richTextBox1.Text += str;
            break;
          case 1195724803:
            if (!(text1 == "tr"))
              break;
            string text5 = new TesseractEngine("./tessdatatur", "tur").Process(image).GetText();
            char[] chArray4 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text5.Split(chArray4))
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + str + " ";
            }
            break;
          case 1461901041:
            if (!(text1 == "fr"))
              break;
            string text6 = new TesseractEngine("./tessdatafra", "fra").Process(image).GetText();
            char[] chArray5 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text6.Split(chArray5))
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + str + " ";
            }
            break;
          case 1562713850:
            if (!(text1 == "ar"))
              break;
            string text7 = new TesseractEngine("./tessdataara", "ara").Process(image).GetText();
            char[] chArray6 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text7.Split(chArray6))
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + str + " ";
            }
            break;
          case 1816099348:
            if (!(text1 == "ja"))
              break;
            string text8 = new TesseractEngine("./tessdatajap", "jpn").Process(image).GetText();
            char[] chArray7 = new char[6]
            {
              '\n',
              '|',
              '-',
              ',',
              '"',
              '/'
            };
            foreach (string str in text8.Split(chArray7))
            {
              RichTextBox richTextBox1 = this.richTextBox1;
              richTextBox1.Text = richTextBox1.Text + str + " ";
            }
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void button1_Click(object sender, EventArgs e) => this.ff();

    public void ret()
    {
      if (this.frm2 == null || this.frm2.IsDisposed)
      {
        this.frm2 = new Form2();
        this.frm2.Show();
      }
      else
      {
        int num = (int) MessageBox.Show("Seçim Bölgesi Zaten Açık");
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      try
      {
        if (!(this.chrome.Address == this.ggarmy))
          return;
        this.panel1.Enabled = false;
        this.panel1.Visible = false;
      }
      catch (Exception ex)
      {
      }
    }

    private void richTextBox1_DoubleClick(object sender, EventArgs e)
    {
      Clipboard.SetText(this.richTextBox1.Text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.button2.Visible = false;
      this.button3.Visible = true;
      this.panel3.Visible = true;
      this.listBox1.Visible = true;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.button2.Visible = true;
      this.button3.Visible = false;
      this.panel3.Visible = false;
      this.listBox1.Visible = false;
    }

    public void translate()
    {
      this.chrome23c.Load("https://translate.google.com.tr/#" + this.comboBox1.Text + "/" + this.comboBox2.Text + "/" + this.richTextBox1.Text + ".");
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.linkLabel1.LinkVisited = true;
      Process.Start("https://raw-edits.godaddysites.com/");
    }

    private void Form1_DoubleClick(object sender, EventArgs e)
    {
    }

    private void richTextBox2_DoubleClick(object sender, EventArgs e)
    {
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.panel3.Visible = true;
      this.chrome222 = new ChromiumWebBrowser(this.listBox1.SelectedItem.ToString());
      this.panel3.Controls.Add((Control) this.chrome222);
      this.chrome222.Dock = DockStyle.Fill;
      this.chrome222.Load(this.listBox1.SelectedItem.ToString());
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      try
      {
        if (!(this.chrome222.Address == this.ggarmy))
          return;
        this.panel3.Enabled = false;
        this.panel3.Visible = false;
      }
      catch (Exception ex)
      {
      }
    }

    private void button4_Click(object sender, EventArgs e) => this.translate();

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.button1 = new Button();
      this.pictureBox1 = new PictureBox();
      this.richTextBox1 = new RichTextBox();
      this.listBox1 = new ListBox();
      this.comboBox1 = new ComboBox();
      this.comboBox2 = new ComboBox();
      this.timer1 = new Timer(this.components);
      this.button2 = new Button();
      this.button3 = new Button();
      this.linkLabel1 = new LinkLabel();
      this.panel3 = new Panel();
      this.timer2 = new Timer(this.components);
      this.panel2 = new Panel();
      this.button4 = new Button();
      this.panel1 = new Panel();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button1.BackColor = SystemColors.ActiveCaption;
      this.button1.Location = new Point(506, 5);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 21);
      this.button1.TabIndex = 0;
      this.button1.Text = "Yazdır";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pictureBox1.BackColor = Color.Silver;
      this.pictureBox1.Location = new Point(506, 29);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(282, 81);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      this.richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.richTextBox1.BackColor = Color.White;
      this.richTextBox1.Location = new Point(506, 116);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(282, 124);
      this.richTextBox1.TabIndex = 3;
      this.richTextBox1.Text = "";
      this.richTextBox1.DoubleClick += new EventHandler(this.richTextBox1_DoubleClick);
      this.listBox1.BackColor = SystemColors.HotTrack;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(18, 34);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(182, 147);
      this.listBox1.TabIndex = 0;
      this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(587, 5);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(97, 21);
      this.comboBox1.TabIndex = 0;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new Point(691, 5);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(97, 21);
      this.comboBox2.TabIndex = 0;
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.button2.BackColor = Color.FromArgb((int) byte.MaxValue, 192, 192);
      this.button2.Location = new Point(12, 5);
      this.button2.Name = "button2";
      this.button2.Size = new Size(58, 23);
      this.button2.TabIndex = 7;
      this.button2.Text = "DESTEK";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.BackColor = Color.FromArgb((int) byte.MaxValue, 192, 192);
      this.button3.Location = new Point(12, 5);
      this.button3.Name = "button3";
      this.button3.Size = new Size(58, 23);
      this.button3.TabIndex = 0;
      this.button3.Text = "DESTEK";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = SystemColors.ButtonHighlight;
      this.linkLabel1.Location = new Point(76, 5);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(124, 13);
      this.linkLabel1.TabIndex = 0;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Sorun Mu Yaşıyorsunuz?";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.panel3.BackColor = Color.Silver;
      this.panel3.Location = new Point(12, 246);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(488, 289);
      this.panel3.TabIndex = 1;
      this.timer2.Enabled = true;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.panel2.BackColor = Color.Silver;
      this.panel2.Controls.Add((Control) this.button4);
      this.panel2.Location = new Point(506, 246);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(282, 440);
      this.panel2.TabIndex = 1;
      this.button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button4.AutoSize = true;
      this.button4.BackColor = Color.White;
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button4.ForeColor = Color.SteelBlue;
      this.button4.Location = new Point(0, 0);
      this.button4.Name = "button4";
      this.button4.Size = new Size(282, 59);
      this.button4.TabIndex = 0;
      this.button4.Text = "Translate";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.panel1.BackColor = Color.Silver;
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(800, 450);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.richTextBox1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.comboBox2);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Raw Edits";
      this.TransparencyKey = SystemColors.Control;
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.Form1_Load);
      this.DoubleClick += new EventHandler(this.Form1_DoubleClick);
      this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
