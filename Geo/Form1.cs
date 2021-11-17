using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.MapProviders;
using GMap.NET.Projections;

namespace Geo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt|*.txt";
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName;
        }

        private GMarkerGoogle GetMarker(Us us, GMarkerGoogleType gMarkerGoogleType= GMarkerGoogleType.red)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(us.сoordinates[0].lat, us.сoordinates[0].lon), gMarkerGoogleType);//широта, долгота, тип маркера
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);//всплывающее окно с инфой к маркеру
            mapMarker.ToolTipText = us.id; // текст внутри всплывающего окна
            mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver; //как показывает всплывающее окно (тут при наведение)
            return mapMarker;
        }
        private GMapOverlay GetOverlayMarkers(List<Us> uss, string name, GMarkerGoogleType gMarkerGoogleType= GMarkerGoogleType.red)
        {
            GMapOverlay gMapMarkers = new GMapOverlay(name);// создание именованного слоя 
            foreach (Us us in uss)
            {
                gMapMarkers.Markers.Add(GetMarker(us, gMarkerGoogleType));// добавление маркеров на слой
            }
            return gMapMarkers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Us> LUs = new List<Us>().GetList(textBox1.Text, true);

            gMapControl1.Overlays.Clear();
            List<List<Us>> LLUs = LUs.GetListWhereDifference();
            List<Us> groups = LLUs.GetListUs();
            List<Us> withoutGroups = LUs.DropByListId(groups);
            gMapControl1.Overlays.Add(GetOverlayMarkers(groups, "GroupsMarkers"));
            gMapControl1.Overlays.Add(GetOverlayMarkers(withoutGroups, "WithoutGroupsMarkers"));
            GetSbUs();
            if (LLUs.Count > 0)
            {
                GetHeatMap(withoutGroups, "WithoutGroupsPolygons", false);
                GetHeatMap(groups, "GroupsPolygons");
            }
            GetHeatMap(groups.Concat(withoutGroups).ToList(), "AllPolygons", false);
            CheckHeatMap("AllPolygons");
            AllPolygonsToolStripMenuItem.CheckState = CheckState.Checked;
            gMapControl1.Update();// обновить контрол
        }
        void saveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialogforsavemap = new SaveFileDialog())
                {
                    // Формат картинки
                    dialogforsavemap.Filter = "PNG (*.png)|*.png";

                    // Название картинки
                    dialogforsavemap.FileName = "Текущее положение карты";

                    Image image = gMapControl1.ToImage();

                    if (image != null)
                    {
                        using (image)
                        {
                            if (dialogforsavemap.ShowDialog() == DialogResult.OK)
                            {
                                string fileName = dialogforsavemap.FileName;
                                if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                    fileName += ".png";

                                image.Save(fileName);
                                MessageBox.Show("Карта успешно сохранена в директории: " + Environment.NewLine + dialogforsavemap.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }

            // Если ошибка
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка при сохранении карты: " + Environment.NewLine + exception.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            //mapView.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMapQuestHybrid;
            //mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// центр россии
            gMapControl1.Zoom = 4;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;// как приблежает(просто в центр карты или по положению мышы) 
            gMapControl1.CanDragMap = true; // перетаскивание карты мышью
            gMapControl1.DragButton = MouseButtons.Left;// какой кнопкой перетаскивание
            gMapControl1.ShowCenter = false;//показывать или скрывать красный крестик в центре
            gMapControl1.ShowTileGridLines = false; //показывать или скрывать тайлы
        }
        private void ClearMap_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays[0].IsVisibile = false;
            gMapControl1.Overlays.Clear();
            gMapControl1.Update();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DopF dopF = new DopF();
            dopF.ShowDialog();
        }
        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            Clipboard.SetText(item.ToolTipText);
        }
        private void gMapControl1_OnMapZoomChanged()
        {
            if (AllPolygonsToolStripMenuItem.CheckState == CheckState.Checked)
            {
                CheckHeatMap("AllPolygons");
                gMapControl1.Update();
            }
            if (GroupsPolygonsToolStripMenuItem.CheckState == CheckState.Checked)
            {
                CheckHeatMap("GroupsPolygons");
                gMapControl1.Update();
            }
            if (WitoutGroupsPolygonsToolStripMenuItem.CheckState == CheckState.Checked)
            {
                CheckHeatMap("WithoutGroupsPolygons");
                gMapControl1.Update();
            }
        }
        public void GetHeatMap(List<Us> LUs, string name, bool AllCoord = true)
        {
            MercatorProjection mercatorProjection = new MercatorProjection(); // класс с функциями https://github.com/radioman/greatmaps/blob/master/GMap.NET.Core/GMap.NET.Projections/MercatorProjection.cs#L73
            for (int myZoom = gMapControl1.MinZoom + 3; myZoom <= gMapControl1.MaxZoom + 3; myZoom++)
            {
                GMapOverlay gMapOverlay = new GMapOverlay(name + myZoom); // создание слоя с именем включающий зум
                int tileSizePx = (int)mercatorProjection.TileSize.Height; //размер тайла
                List<GPoint> gPoints = new List<GPoint>();//список точек 
                foreach (Us us in LUs)
                {
                    if (AllCoord)
                    {
                        foreach (Coordinat coordinat in us.сoordinates)
                        {
                            GPoint pixelCoord = mercatorProjection.FromLatLngToPixel(coordinat.lat, coordinat.lon, myZoom);
                            gPoints.Add(new GPoint(pixelCoord.X / tileSizePx * tileSizePx, pixelCoord.Y / tileSizePx * tileSizePx));
                        }
                    }
                    else
                    {
                        GPoint pixelCoord = mercatorProjection.FromLatLngToPixel(us.сoordinates[0].lat, us.сoordinates[0].lon, myZoom);//из широты долготы в пиксели
                        gPoints.Add(new GPoint(pixelCoord.X / tileSizePx * tileSizePx, pixelCoord.Y / tileSizePx * tileSizePx));
                    }
                }
                var group = gPoints.GroupBy(r => r).ToList();
                int TileMaxCount = group.Max(r => r.Count());// максимальное содержанее маркеров на тайле
                foreach (var item in group)
                {
                    int minus = Convert.ToInt32(155 * item.Count() / TileMaxCount);//сколько вычитать из РГБ
                    if (minus == 0) { minus++; }
                    Color color = Color.FromArgb(200, 255, 155 - minus, 155 - minus);// задаем цвет для использования
                    List<PointLatLng> pointLatLngs = new List<PointLatLng>()
                {
                    mercatorProjection.FromPixelToLatLng(item.Key, myZoom),
                    mercatorProjection.FromPixelToLatLng(item.Key.X+tileSizePx, item.Key.Y, myZoom),
                    mercatorProjection.FromPixelToLatLng(item.Key.X+tileSizePx, item.Key.Y+tileSizePx, myZoom),
                    mercatorProjection.FromPixelToLatLng(item.Key.X, item.Key.Y+tileSizePx, myZoom)
                }; //создаем список точек для полигона
                    GMapPolygon gMapPolygon = new GMapPolygon(pointLatLngs, item.Key.ToString()); //создаем полигон из списка точек
                    gMapPolygon.Fill = new SolidBrush(color);// заливка
                    gMapPolygon.Stroke = new Pen(color, -1); // рамка
                    gMapPolygon.IsVisible = true; // видимость 
                    gMapOverlay.Polygons.Add(gMapPolygon); // добавляем полигон
                }
                gMapControl1.Overlays.Add(gMapOverlay);// добавляем слой
                GC.Collect();// сбор мусора
            }
            //return gMapOverlay;
        }

        private void groupsOverlay_Click(object sender, EventArgs e)
        {
            if (groupsOverlay.CheckState == CheckState.Checked)
            {
                gMapControl1.Overlays[0].IsVisibile = false;
                groupsOverlay.CheckState = CheckState.Unchecked;
                gMapControl1.Update();
            }
            else
            {
                gMapControl1.Overlays[0].IsVisibile = true;
                groupsOverlay.CheckState = CheckState.Checked;
                gMapControl1.Update();
            }
        }
        private void WithoutGroupsOverlay_Click(object sender, EventArgs e)
        {

            if (WithoutGroupsOverlay.CheckState == CheckState.Checked)
            {
                gMapControl1.Overlays[1].IsVisibile = false;
                WithoutGroupsOverlay.CheckState = CheckState.Unchecked;
                gMapControl1.Update();
            }
            else
            {
                gMapControl1.Overlays[1].IsVisibile = true;
                WithoutGroupsOverlay.CheckState = CheckState.Checked;
                gMapControl1.Update();
            }
        }

        private void AllPolygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AllPolygonsToolStripMenuItem.Checked)
            {
                AllPolygonsToolStripMenuItem.Checked = true;
                GroupsPolygonsToolStripMenuItem.Checked = false;
                WitoutGroupsPolygonsToolStripMenuItem.Checked = false;
                CheckHeatMap("AllPolygons");
                gMapControl1.Update();
            }
            else
            {
                AllPolygonsToolStripMenuItem.Checked = false;
                CheckHeatMap(null);
            }

        }

        private void GroupsPolygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GroupsPolygonsToolStripMenuItem.Checked)
            {
                GroupsPolygonsToolStripMenuItem.Checked = true;
                AllPolygonsToolStripMenuItem.Checked = false;
                WitoutGroupsPolygonsToolStripMenuItem.Checked = false;
                CheckHeatMap("GroupsPolygons");
                gMapControl1.Update();
            }
            else
            {
                GroupsPolygonsToolStripMenuItem.Checked = false;
                CheckHeatMap(null);
            }
        }

        private void WitoutGroupsPolygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!WitoutGroupsPolygonsToolStripMenuItem.Checked)
            {
                WitoutGroupsPolygonsToolStripMenuItem.Checked = true;
                GroupsPolygonsToolStripMenuItem.Checked = false;
                AllPolygonsToolStripMenuItem.Checked = false;
                CheckHeatMap("WithoutGroupsPolygons");
                gMapControl1.Update();
            }
            else
            {
                WitoutGroupsPolygonsToolStripMenuItem.Checked = false;
                CheckHeatMap(null);
            }
        }
        private void CheckHeatMap(string name)
        {
            foreach (GMapOverlay gMapOverlay in gMapControl1.Overlays.Where(r => r.Id.Contains("Polygons")))
            {
                gMapOverlay.IsVisibile = false;
            }// все слои содержащие слово полигон невидимы
            if (name != null)
            {
                name += gMapControl1.Zoom + 3;
                GMapOverlay gMapOverlaySearch = gMapControl1.Overlays.Where(r => r.Id == name).FirstOrDefault();
                gMapControl1.Overlays.Where(r => r.Id == name).FirstOrDefault().IsVisibile = true;//видимость слоя с заданным именем
            }
        }

        private void InfoFromScreen_Click(object sender, EventArgs e)
        {
            var a = gMapControl1.ViewArea;
            List<UsStart> usStarts = new List<UsStart>();
            if (WithoutGroupsOverlay.CheckState == CheckState.Checked)
            {
                List<GMapMarker> mapMarkers = gMapControl1.Overlays[1].Markers.Where(r => r.Position.Lng >= gMapControl1.ViewArea.Left
                && r.Position.Lng <= gMapControl1.ViewArea.Right
                && r.Position.Lat >= gMapControl1.ViewArea.Bottom
                && r.Position.Lat <= gMapControl1.ViewArea.Top).ToList();
                foreach (GMapMarker gMapMarker in mapMarkers)
                {
                    usStarts.Add(new UsStart() { id = gMapMarker.ToolTipText, lat = gMapMarker.Position.Lat, lon = gMapMarker.Position.Lng });
                }
            }
            if (groupsOverlay.CheckState == CheckState.Checked)
            {
                List<GMapMarker> mapMarkers = gMapControl1.Overlays[0].Markers.Where(r=>r.Position.Lng>= gMapControl1.ViewArea.Left 
                && r.Position.Lng <= gMapControl1.ViewArea.Right
                && r.Position.Lat >= gMapControl1.ViewArea.Bottom
                && r.Position.Lat <= gMapControl1.ViewArea.Top).ToList();
                foreach(GMapMarker gMapMarker in mapMarkers)
                {
                    usStarts.Add(new UsStart() { id = gMapMarker.ToolTipText, lat = gMapMarker.Position.Lat, lon = gMapMarker.Position.Lng });
                }
            }
            usStarts.Write("selectedUs.txt");
            if (BUS.CheckState==CheckState.Checked)
            {
                usStarts = new List<UsStart>();
                List<GMapMarker> mapMarkers = gMapControl1.Overlays.FirstOrDefault(r=>r.Id== "Us").Markers.Where(r => r.Position.Lng >= gMapControl1.ViewArea.Left
                && r.Position.Lng <= gMapControl1.ViewArea.Right
                && r.Position.Lat >= gMapControl1.ViewArea.Bottom
                && r.Position.Lat <= gMapControl1.ViewArea.Top).ToList();
                foreach (GMapMarker gMapMarker in mapMarkers)
                {
                    usStarts.Add(new UsStart() { id = gMapMarker.ToolTipText, lat = gMapMarker.Position.Lat, lon = gMapMarker.Position.Lng });
                }
                usStarts.Write("selectedBanUs.txt");
            }
        }
        private void GetSbUs()
        {
            string name = Environment.CurrentDirectory + "\\US.txt";
            if (File.Exists(name))
            {
                List<Us> LUs = new List<Us>().GetList(name, true);
                gMapControl1.Overlays.Add(GetOverlayMarkers(LUs, "Us", GMarkerGoogleType.green));
                BUS.CheckState = CheckState.Checked;
            }
            else { BUS.Visible = false; }

        }

        private void BUS_Click(object sender, EventArgs e)
        {

            if (BUS.CheckState == CheckState.Checked)
            {
                gMapControl1.Overlays[2].IsVisibile = false;
                BUS.CheckState = CheckState.Unchecked;
                gMapControl1.Update();
            }
            else
            {
                gMapControl1.Overlays[2].IsVisibile = true;
                BUS.CheckState = CheckState.Checked;
                gMapControl1.Update();
            }
        }

        private void addMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".txt|*.txt";
            ofd.ShowDialog();
            if(ofd.FileName=="" || ofd.FileName == null) { return; }
            List<Us> LUs = new List<Us>().GetList(ofd.FileName, true);
            gMapControl1.Overlays.Add(GetOverlayMarkers(LUs, "DopM", GMarkerGoogleType.blue));

        }
    }
}
