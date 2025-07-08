using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using sdr.Helpers;
using sdr.Services;
using sdr.Models;
namespace sdr
{

    public partial class adminForm : Form
    {
        private SiparisService _siparisService;
        bool mouseInSubMenu = false;
        bool mouseInMainButton = false;
        Timer closeTimer;
        private CyberButton quitButton;
        private int _radius = 30;
        private Color startColor = Color.FromArgb(0, 0, 64);   // Başlangıç rengi
        private Color targetColor = Color.FromArgb(0, 0, 100); // Hover rengi
        private CircleProgressBar dailyProgress;
        private CircleProgressBar monthlyProgress;
        private Timer refreshTimer;
        Timer adminTimer;
        public adminForm()
        {
            InitializeComponent();
            CheckPermissionsRecursive(this.Controls);
            _siparisService = new SiparisService();
            closeTimer = new Timer();
            closeTimer.Interval = 300; // 300 ms gecikme
            closeTimer.Tick += CloseTimer_Tick;

            panelSettingsSubMenu.MouseEnter += (s, e2) => { mouseInSubMenu = true; closeTimer.Stop(); };
            panelSettingsSubMenu.MouseLeave += (s, e2) => { mouseInSubMenu = false; closeTimer.Start(); };

            settingsButton.MouseEnter += (s, e2) => { mouseInMainButton = true; closeTimer.Stop(); };
            settingsButton.MouseLeave += (s, e2) => { mouseInMainButton = false; closeTimer.Start(); };

            refreshTimer = new Timer();
            refreshTimer.Interval = 6000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
            dailyProgress = new ReaLTaiizor.Controls.CircleProgressBar();
            monthlyProgress = new ReaLTaiizor.Controls.CircleProgressBar();

            dailyProgress.Location = new Point(638, 152);
            dailyProgress.Size = new Size(189, 189);
            dailyProgress.PercentColor = Color.White;
            dailyProgress.ProgressColor1 = Color.FromArgb(255, 128, 0);
            dailyProgress.ProgressColor2 = Color.MediumOrchid;

            monthlyProgress.Location = new Point(869, 152);
            monthlyProgress.Size = new Size(189, 189);
            monthlyProgress.PercentColor = Color.White;
            monthlyProgress.ProgressColor1 = Color.MediumOrchid;
            monthlyProgress.ProgressColor2 = Color.Pink;
            this.Controls.Add(dailyProgress);
            this.Controls.Add(monthlyProgress);


         
        }
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            if (!mouseInMainButton && !mouseInSubMenu)
            {
                panelSettingsSubMenu.Visible = false;
                closeTimer.Stop();
            }
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {

        }

        private void CheckPermissionsRecursive(Control.ControlCollection controls)
        {
            var userPermissions = Session.UserPermissions;

            foreach (Control ctrl in controls)
            {         
                if (ctrl.Tag == null || string.IsNullOrWhiteSpace(ctrl.Tag.ToString()))
                {
                    ctrl.Visible = true;
                }
                else
                { 
                    if ((ctrl is LostButton || ctrl is CyberButton))
                    {
                        string requiredPermission = ctrl.Tag.ToString();
                        ctrl.Visible = userPermissions.Contains(requiredPermission);
                    }
                    else
                    {
                        
                        ctrl.Visible = true;
                    }
                }
                if (ctrl.HasChildren)
                {
                    CheckPermissionsRecursive(ctrl.Controls);
                }
            }
        }



        private async void adminForm_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("sdr_logo.ico");
            adminTimer = new Timer();
            panelSettingsSubMenu.Visible = false;
            settingsButton.MouseEnter += settingsButton_MouseEnter;
            settingsButton.MouseLeave += settingsButton_MouseLeave;
            //salesButton.MouseEnter += salesButton_MouseEnter;
            salesButton.MouseLeave += salesButton_MouseLeave;

            formStyle_1();
            SetRoundedRegion(_radius);
            // await login();
            LoadSalesData();
            adminTimer.Interval = 10 * 60 * 1000;
            adminTimer.Tick += (s, args) => LoadSalesData();
            adminTimer.Start();



            foreach (Control ctr in this.Controls)
            {
                if (ctr is ReaLTaiizor.Controls.LostButton btn)
                {
                    ApplyHoverEffect(btn,
                    Color.FromArgb(0, 0, 64),     
                    Color.FromArgb(0, 0, 100),   
                    Color.White,                    
                    Color.OrangeRed                    
            );
                }
            }



        }
        private void ApplyPermissions(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is LostButton btn && btn.Tag != null)
                {
                    string requiredPermission = btn.Tag.ToString();

                    if (!Session.UserPermissions.Contains(requiredPermission))
                    {
                        btn.Visible = false; 
                    }
                }
         if (ctrl.HasChildren)
                {
                    ApplyPermissions(ctrl.Controls);
                }
            }
        }
       
        public async Task login()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Visible = false;
            }
            

            Label dynamicLabel = new Label();
            dynamicLabel.Text = "Welcome to SDR Systems";
            dynamicLabel.ForeColor = Color.White;
            dynamicLabel.AutoSize = true;
            dynamicLabel.Location = new Point(329, 271);
            dynamicLabel.Font = new Font("Inter", 24);
            this.Controls.Add(dynamicLabel);
            dynamicLabel.BringToFront();
            dynamicLabel.Visible = true;

           
            var tcs = new TaskCompletionSource<bool>();

            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();

                if (dynamicLabel != null)
                {
                    this.Controls.Remove(dynamicLabel);
                    dynamicLabel.Dispose();
                    dynamicLabel = null;
                }

                
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Visible = true;
                }

                tcs.SetResult(true);  
            };
            timer.Start();

            await tcs.Task;  
        }


        void formStyle_1()
        {

            this.Load += adminForm_Load;
            this.DoubleBuffered = true;
        }

        private void ApplyHoverEffect(Control target, Color startBackColor, Color endBackColor, Color startForeColor, Color endForeColor)
        {
            Timer hoverTimer = new Timer();
            hoverTimer.Interval = 25;

            Color currentBack = startBackColor;
            Color currentFore = startForeColor;

            bool hovering = false;

            target.BackColor = startBackColor;
            target.ForeColor = startForeColor;

            hoverTimer.Tick += (s, e) =>
            {
                Color backTarget = hovering ? endBackColor : startBackColor;
                Color foreTarget = hovering ? endForeColor : startForeColor;

                currentBack = Color.FromArgb(
                    Lerp(currentBack.R, backTarget.R, 0.05),
                    Lerp(currentBack.G, backTarget.G, 0.05),
                    Lerp(currentBack.B, backTarget.B, 0.05)
                );

                currentFore = Color.FromArgb(
                    Lerp(currentFore.R, foreTarget.R, 0.2),
                    Lerp(currentFore.G, foreTarget.G, 0.2),
                    Lerp(currentFore.B, foreTarget.B, 0.2)
                );

                target.BackColor = currentBack;
                target.ForeColor = currentFore;

                if (currentBack == backTarget && currentFore == foreTarget)
                {
                    hoverTimer.Stop();
                }
            };

            target.MouseEnter += (s, e) =>
            {
                hovering = true;
                hoverTimer.Start();
            };

            target.MouseLeave += (s, e) =>
            {
                hovering = false;
                hoverTimer.Start();
            };


        }





        private int Lerp(int start, int end, double amount)
        {
            return (int)(start + (end - start) * amount);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = _radius;
            int diameter = radius * 2;
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);

            using (GraphicsPath path = new GraphicsPath())
            using (Pen borderPen = new Pen(Color.FromArgb(0, 0, 154), 2))
            {
                path.StartFigure();
                path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter - 1, bounds.Top, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter - 1, bounds.Bottom - diameter - 1, diameter, diameter, 0, 90);
                path.AddArc(bounds.Left, bounds.Bottom - diameter - 1, diameter, diameter, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(borderPen, path);

            }
        }

        private void SetRoundedRegion(int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);


            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }


        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            SetRoundedRegion(_radius);
        }
        private void parrotCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


        private void OpenFormByName(string formName)
        {
            Form formToOpen = null;

            if (formName == "DatabaseInformation")
                formToOpen = new DatabaseInformation();
            else if (formName == "CreateUserForm")
                formToOpen = new CreateUser();
            else if (formName == "RolePermissionForm")
                formToOpen = new rolePermissionForm();
            else if (formName == "RoleAddForm")
                formToOpen = new roleAddForm();
            else if (formName == "customers")
                formToOpen = new customers();
            else if (formName == "createSale")
                formToOpen = new createSale();
            else if (formName == "FirmaBilgileriModel")
                formToOpen = new FirmaAyarlariForm();


            if (formToOpen != null)
                formToOpen.Show();
        }
        private void ShowSubMenu(Control mainButton, List<(string Text, string formName, EventHandler OnClick, string PermissionKey)> submenuItems)
        {
            panelSettingsSubMenu.Controls.Clear();
            int top = 0;

            foreach (var item in submenuItems)
            {
               

                string formName = item.formName;

                LostButton subBtn = new LostButton
                {
                    Text = item.Text,
                    Width = 150,
                    Height = 30,
                    Left = 0,
                    Top = top
                };

                subBtn.Click += (s, e) => OpenFormByName(formName);
                subBtn.MouseEnter += (s, e2) => { mouseInSubMenu = true; closeTimer.Stop(); };
                subBtn.MouseLeave += (s, e2) => { mouseInSubMenu = false; closeTimer.Start(); };

                panelSettingsSubMenu.Controls.Add(subBtn);
                top += subBtn.Height + 2;
            }

            if (panelSettingsSubMenu.Controls.Count == 0)
            {
                panelSettingsSubMenu.Visible = false;
                return;
            }

            Point btnScreenPos = mainButton.PointToScreen(Point.Empty);
            Point formScreenPos = this.PointToScreen(Point.Empty);
            int relativeX = btnScreenPos.X - formScreenPos.X;
            int relativeY = btnScreenPos.Y - formScreenPos.Y;

            panelSettingsSubMenu.Left = relativeX + mainButton.Width + 5;
            panelSettingsSubMenu.Top = relativeY;
            panelSettingsSubMenu.Width = 150;
            panelSettingsSubMenu.Height = top;

            panelSettingsSubMenu.Visible = true;
        }
        private void bigLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customersButton_Click(object sender, EventArgs e)
        {

        }

        private void cyberGroupBox1_Load(object sender, EventArgs e)
        {

        }

        private void personelButton_Click(object sender, EventArgs e)
        {
            personelForm personelForm = new personelForm();
            personelForm.ShowDialog();
        }

        private void salesButton_Click(object sender, EventArgs e)
        {
            sales saleForm = new sales();
            saleForm.Show();
        }


        private void dailyProgress_Click(object sender, EventArgs e)
        {

        }

        private void monthlyProgress_Click(object sender, EventArgs e)
        {

        }

        private void lostButton1_Click(object sender, EventArgs e)
        {

        }

        private void createSaleButton_Click(object sender, EventArgs e)
        {
            createSale createSaleForm = new createSale();
            createSaleForm.Show();

        }

        private void customersButton_Click_1(object sender, EventArgs e)
        {
            customers CustomersForm = new customers();
            CustomersForm.Show();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginForm = new login();
            loginForm.Show();
        }


        private void btnData_Click(object sender, EventArgs e)
        {
            DatabaseInformation databaseInformation = new DatabaseInformation();
            databaseInformation.Show();
        }
        
        public void settingsButton_MouseEnter(object sender, EventArgs e)

        {

            mouseInMainButton = true;
            closeTimer.Stop();

            ShowSubMenu(settingsButton, new List<(string Text, string formName, EventHandler OnClick, string PermissionKey)>
    {
        ("Database Configure", "DatabaseInformation", btnData_Click, "DatabaseInformation"),
        ("Create User", "CreateUserForm", customersButton_Click_1, "CreateUser"),
        ("Roles-Permissions", "RolePermissionForm", customersButton_Click_1, "rolePermissionForm"),
        ("Create a new Rule", "RoleAddForm", customersButton_Click_1, "roleAddForm"),
        ("Company Information", "FirmaBilgileriModel", customersButton_Click_1, "FirmaBilgileriModel")
    });
        }


        private void LoadSalesData()
        {
            int dailySales = 0;
            int monthlySales = 0;
            _siparisService.GetDailyAndMonthlyTotalSales(out dailySales, out monthlySales);
            dailyProgress.Value = dailySales;
            monthlyProgress.Value= monthlySales; 
                Timer timer = new Timer();
                timer.Interval = 30; 
                timer.Tick += (s, e) =>
                {
                    if (dailyProgress.Value < dailySales)
                        dailyProgress.Value += 1;


                    if (monthlyProgress.Value < monthlySales)
                        monthlyProgress.Value += 1;

                    if (dailyProgress.Value >= dailySales && monthlyProgress.Value >= monthlySales)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                };
                dailyProgress.Value = 0;
                monthlyProgress.Value = 0;
                timer.Start();
        }


        private void btnRefreshSales_Click(object sender, EventArgs e)
        {
            LoadSalesData();
            MessageBox.Show("Satış verileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    


    private void settingsButton_MouseLeave(object sender, EventArgs e)
        {
            mouseInMainButton = false;
            closeTimer.Start();
        }

    //    private void salesButton_MouseEnter(object sender, EventArgs e)
    //    {
    //        mouseInMainButton = true;
    //        closeTimer.Stop();

    //        ShowSubMenu(salesButton, new List<(string Text, string formName, EventHandler OnClick, string permissionKey)>
    //{
    //    ("Create Sale", "createSale", createSaleButton_Click,""),
    //    ("Customers", "customers", customersButton_Click_1,"")
    //});
    //    }

        private void salesButton_MouseLeave(object sender, EventArgs e)
        {
            mouseInMainButton = false;
            closeTimer.Start();
        }

        private void panelSettingsSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

   
        private void lblDailyCount_Click(object sender, EventArgs e)
        {

        }

        private void stokEntryButton_Click(object sender, EventArgs e)
        {
            StokGiris stokgirisForm = new StokGiris();
            stokgirisForm.Show();
        }
    }
}
