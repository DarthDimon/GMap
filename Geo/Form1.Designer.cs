
namespace Geo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MarkerOverlays = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.WithoutGroupsOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.BUS = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonsOrerlays = new System.Windows.Forms.ToolStripMenuItem();
            this.AllPolygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupsPolygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WitoutGroupsPolygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoFromScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(2, 47);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 15;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(752, 426);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 2D;
            this.gMapControl1.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl1_OnMarkerClick);
            this.gMapControl1.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl1_OnMapZoomChanged);
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.ClearMap,
            this.MarkerOverlays,
            this.PolygonsOrerlays,
            this.InfoFromScreen,
            this.addMarkerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(264, 158);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(263, 22);
            this.saveMenuItem.Text = "Сохранить изображение";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // ClearMap
            // 
            this.ClearMap.Name = "ClearMap";
            this.ClearMap.Size = new System.Drawing.Size(263, 22);
            this.ClearMap.Text = "Очистить карту";
            this.ClearMap.Click += new System.EventHandler(this.ClearMap_Click);
            // 
            // MarkerOverlays
            // 
            this.MarkerOverlays.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupsOverlay,
            this.WithoutGroupsOverlay,
            this.BUS});
            this.MarkerOverlays.Name = "MarkerOverlays";
            this.MarkerOverlays.Size = new System.Drawing.Size(263, 22);
            this.MarkerOverlays.Text = "Маркеры";
            // 
            // groupsOverlay
            // 
            this.groupsOverlay.Checked = true;
            this.groupsOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.groupsOverlay.Name = "groupsOverlay";
            this.groupsOverlay.Size = new System.Drawing.Size(127, 22);
            this.groupsOverlay.Text = "Группы";
            this.groupsOverlay.Click += new System.EventHandler(this.groupsOverlay_Click);
            // 
            // WithoutGroupsOverlay
            // 
            this.WithoutGroupsOverlay.Checked = true;
            this.WithoutGroupsOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WithoutGroupsOverlay.Name = "WithoutGroupsOverlay";
            this.WithoutGroupsOverlay.Size = new System.Drawing.Size(127, 22);
            this.WithoutGroupsOverlay.Text = "Без групп";
            this.WithoutGroupsOverlay.Click += new System.EventHandler(this.WithoutGroupsOverlay_Click);
            // 
            // BUS
            // 
            this.BUS.Name = "BUS";
            this.BUS.Size = new System.Drawing.Size(127, 22);
            this.BUS.Text = "US";
            this.BUS.Click += new System.EventHandler(this.BUS_Click);
            // 
            // PolygonsOrerlays
            // 
            this.PolygonsOrerlays.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllPolygonsToolStripMenuItem,
            this.GroupsPolygonsToolStripMenuItem,
            this.WitoutGroupsPolygonsToolStripMenuItem});
            this.PolygonsOrerlays.Name = "PolygonsOrerlays";
            this.PolygonsOrerlays.Size = new System.Drawing.Size(263, 22);
            this.PolygonsOrerlays.Text = "Тепловая карта";
            // 
            // AllPolygonsToolStripMenuItem
            // 
            this.AllPolygonsToolStripMenuItem.Name = "AllPolygonsToolStripMenuItem";
            this.AllPolygonsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.AllPolygonsToolStripMenuItem.Text = "Все";
            this.AllPolygonsToolStripMenuItem.Click += new System.EventHandler(this.AllPolygonsToolStripMenuItem_Click);
            // 
            // GroupsPolygonsToolStripMenuItem
            // 
            this.GroupsPolygonsToolStripMenuItem.Name = "GroupsPolygonsToolStripMenuItem";
            this.GroupsPolygonsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.GroupsPolygonsToolStripMenuItem.Text = "Группы";
            this.GroupsPolygonsToolStripMenuItem.Click += new System.EventHandler(this.GroupsPolygonsToolStripMenuItem_Click);
            // 
            // WitoutGroupsPolygonsToolStripMenuItem
            // 
            this.WitoutGroupsPolygonsToolStripMenuItem.Name = "WitoutGroupsPolygonsToolStripMenuItem";
            this.WitoutGroupsPolygonsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.WitoutGroupsPolygonsToolStripMenuItem.Text = "Без групп";
            this.WitoutGroupsPolygonsToolStripMenuItem.Click += new System.EventHandler(this.WitoutGroupsPolygonsToolStripMenuItem_Click);
            // 
            // InfoFromScreen
            // 
            this.InfoFromScreen.Name = "InfoFromScreen";
            this.InfoFromScreen.Size = new System.Drawing.Size(263, 22);
            this.InfoFromScreen.Text = "Id и координаты тех что на экране";
            this.InfoFromScreen.Click += new System.EventHandler(this.InfoFromScreen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(685, 12);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 19);
            this.button3.TabIndex = 4;
            this.button3.Text = "Dop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // addMarkerToolStripMenuItem
            // 
            this.addMarkerToolStripMenuItem.Name = "addMarkerToolStripMenuItem";
            this.addMarkerToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.addMarkerToolStripMenuItem.Text = "addMarker";
            this.addMarkerToolStripMenuItem.Click += new System.EventHandler(this.addMarkerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 473);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearMap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem MarkerOverlays;
        private System.Windows.Forms.ToolStripMenuItem groupsOverlay;
        private System.Windows.Forms.ToolStripMenuItem WithoutGroupsOverlay;
        private System.Windows.Forms.ToolStripMenuItem PolygonsOrerlays;
        private System.Windows.Forms.ToolStripMenuItem AllPolygonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GroupsPolygonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WitoutGroupsPolygonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoFromScreen;
        private System.Windows.Forms.ToolStripMenuItem BUS;
        private System.Windows.Forms.ToolStripMenuItem addMarkerToolStripMenuItem;
    }
}

