using System;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace testApp
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser chromeBrowser;
        private Panel buttonPanel;
        private Button button1;
        private Button button2;
        private Button button3;

        public Form1()
        {
            InitializeComponent();
            InitializeChromiumWithButtons();
        }

        private void InitializeChromiumWithButtons()
        {
            // CefSharp 초기화 (추가 설정이 필요한 경우 CefSettings를 수정)
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            // ChromiumWebBrowser 생성 및 설정
            chromeBrowser = new ChromiumWebBrowser("https://www.naver.com")
            {
                Dock = DockStyle.Fill
            };

            // 버튼들이 들어갈 Panel 생성
            buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 60; // 하단 영역 높이 설정

            // Button1 생성 및 설정
            button1 = new Button();
            button1.Text = "Button 1";
            button1.Left = 20;
            button1.Top = 15;
            button1.Click += Button1_Click;

            // Button2 생성 및 설정
            button2 = new Button();
            button2.Text = "Button 2";
            button2.Left = 140;
            button2.Top = 15;
            button2.Click += Button2_Click;

            // Button3 생성 및 설정
            button3 = new Button();
            button3.Text = "Button 3";
            button3.Left = 260;
            button3.Top = 15;
            button3.Click += Button3_Click;

            // Panel에 버튼 추가
            buttonPanel.Controls.Add(button1);
            buttonPanel.Controls.Add(button2);
            buttonPanel.Controls.Add(button3);

            // 폼에 ChromiumWebBrowser와 Panel 추가
            this.Controls.Add(chromeBrowser);
            this.Controls.Add(buttonPanel);
        }

        // 버튼 클릭 이벤트 핸들러
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 1 clicked");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 2 clicked");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 3 clicked");
        }

        // 폼 종료 시 CefSharp 리소스 해제
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Cef.Shutdown();
            base.OnFormClosing(e);
        }
    }
}