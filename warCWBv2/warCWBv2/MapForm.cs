using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;

namespace warCWBv2
{
    public partial class MapForm : Form
    {
        Graphics g;
        List<Territorio> territorioList = new List<Territorio>();
        List<Zona> zonas = GetZonas();
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);
            g.Clear(Color.White);
            pb.Refresh();

            MapManager mm = new MapManager();
            territorioList = CreateTerritorio();
            Timer tm = new Timer();
            tm.Interval = 50;

            tm.Tick += delegate
            {
                pb.Image = mm.Map;
            };
            tm.Start();

            mm.Initialize();
            mm.ClearRandom(territorioList);
            mm.Close();

            pb.MouseDown += (o, mea) =>
            {
                Console.WriteLine(mea.Location.ToString());
                mm.Initialize();
                mm.Clear(Color.Green, mea.Location);
                mm.Close();
            };
        }


        public static List<Zona> GetZonas()
        {
            List<Zona> list = new List<Zona>();
            Zona cic = new Zona(3);
            Zona portao = new Zona(6);
            Zona bairronovo = new Zona(3);
            Zona pinheirinho = new Zona(3);
            Zona stafelicidade = new Zona(4);
            Zona boqueirao = new Zona(3);
            Zona cajuru = new Zona(3);
            Zona matriz = new Zona(10);
            Zona boavista = new Zona(4);

            list.AddRange(new[] { cic, portao, bairronovo, pinheirinho, stafelicidade, boqueirao, cajuru, matriz, boavista });

            return list;
        }

        // reescrever essa parte inteira
        public List<Territorio> CreateTerritorio()
        {
            List<Territorio> list = new List<Territorio>();
            
            // trigger warning: murilo moment
            // YANDERE DEV MOMENT assassinado Moll
            list.Add(new Territorio(false, new Point[]{new Point(233, 263)}, zonas[1], "agua verde"));
            zonas[1].InsertTerr(list[0]);
            list.Add(new Territorio(false, new Point[] { new Point(336, 375) }, zonas[5], "alto boqueirão"));
            zonas[5].InsertTerr(list[1]);
            list.Add(new Territorio(false, new Point[] { new Point(320, 182) }, zonas[7], "alto da xv"));
            zonas[7].InsertTerr(list[2]);
            list.Add(new Territorio(false, new Point[] { new Point(217, 220) }, zonas[7], "batel"));
            zonas[7].InsertTerr(list[3]);
            //    case "_BATEL":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_BOA_VISTA":
            //        list.Add(new Territorio(false, img, zonas[8], name));
            //        zonas[8].InsertTerr(list[0]);
            //        break;
            //    case "_BOQUEIRAO":
            //        list.Add(new Territorio(false, img, zonas[5], name));
            //        zonas[5].InsertTerr(list[0]);
            //        break;
            //    case "_BUTIATUVINHA":
            //        list.Add(new Territorio(false, img, zonas[4], name));
            //        zonas[4].InsertTerr(list[0]);
            //        break;
            //    case "_CABRAL":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_CACHOEIRA":
            //        list.Add(new Territorio(false, img, zonas[8], name));
            //        zonas[8].InsertTerr(list[0]);
            //        break;
            //    case "_CAJURU":
            //        list.Add(new Territorio(false, img, zonas[6], name));
            //        zonas[6].InsertTerr(list[0]);
            //        break;
            //    case "_CAMPO_COMPRIDO":
            //        list.Add(new Territorio(false, img, zonas[4], name));
            //        zonas[4].InsertTerr(list[0]);
            //        break;
            //    case "_CAMPO_DE_SANTANA":
            //        list.Add(new Territorio(false, img, zonas[3], name));
            //        zonas[3].InsertTerr(list[0]);
            //        break;
            //    case "_CENTRO":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_CENTRO_CIVICO":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_CIC":
            //        list.Add(new Territorio(false, img, zonas[0], name));
            //        zonas[0].InsertTerr(list[0]);
            //        break;
            //    case "_FAZENDINHA":
            //        list.Add(new Territorio(false, img, zonas[1], name));
            //        zonas[1].InsertTerr(list[0]);
            //        break;
            //    case "_GANCHINHO":
            //        list.Add(new Territorio(false, img, zonas[2], name));
            //        zonas[2].InsertTerr(list[0]);
            //        break;
            //    case "_JARDIM_BOTANICO":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_JARDIM_DAS_AMERICAS":
            //        list.Add(new Territorio(false, img, zonas[5], name));
            //        zonas[5].InsertTerr(list[0]);
            //        break;
            //    case "_MERCES":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_NOVO_MUNDO":
            //        list.Add(new Territorio(false, img, zonas[1], name));
            //        zonas[1].InsertTerr(list[0]);
            //        break;
            //    case "_ORLEANS":
            //        list.Add(new Territorio(false, img, zonas[4], name));
            //        zonas[4].InsertTerr(list[0]);
            //        break;
            //    case "_PAROLIN":
            //        list.Add(new Territorio(false, img, zonas[1], name));
            //        zonas[1].InsertTerr(list[0]);
            //        break;
            //    case "_PASSAUNA":
            //        list.Add(new Territorio(false, img, zonas[0], name));
            //        zonas[0].InsertTerr(list[0]);
            //        break;
            //    case "_PILARZINHO":
            //        list.Add(new Territorio(false, img, zonas[8], name));
            //        zonas[8].InsertTerr(list[0]);
            //        break;
            //    case "_PINHEIRINHO":
            //        list.Add(new Territorio(false, img, zonas[3], name));
            //        zonas[3].InsertTerr(list[0]);
            //        break;
            //    case "_PORTAO":
            //        list.Add(new Territorio(false, img, zonas[1], name));
            //        zonas[1].InsertTerr(list[0]);
            //        break;
            //    case "_REBOUCAS":
            //        list.Add(new Territorio(false, img, zonas[7], name));
            //        zonas[7].InsertTerr(list[0]);
            //        break;
            //    case "_SANTA_CANDIDA":
            //        list.Add(new Territorio(false, img, zonas[8], name));
            //        zonas[8].InsertTerr(list[0]);
            //        break;
            //    case "_SANTA_FELICIDADE":
            //        list.Add(new Territorio(false, img, zonas[4], name));
            //        zonas[4].InsertTerr(list[0]);
            //        break;
            //    case "_SÃO_MIGUEL":
            //        list.Add(new Territorio(false, img, zonas[0], name));
            //        zonas[0].InsertTerr(list[0]);
            //        break;
            //    case "_SITIO_CERCADO":
            //        list.Add(new Territorio(false, img, zonas[2], name));
            //        zonas[2].InsertTerr(list[0]);
            //        break;
            //    case "_TARUMA":
            //        list.Add(new Territorio(false, img, zonas[8], name));
            //        zonas[8].InsertTerr(list[0]);
            //        break;
            //    case "_TATUQUARA":
            //        list.Add(new Territorio(false, img, zonas[3], name));
            //        zonas[3].InsertTerr(list[0]);
            //        break;
            //    case "_UBERABA":
            //        list.Add(new Territorio(false, img, zonas[6], name));
            //        zonas[6].InsertTerr(list[0]);
            //        break;
            //    case "_UMBARA":
            //        list.Add(new Territorio(false, img, zonas[2], name));
            //        zonas[2].InsertTerr(list[0]);
            //        break;
            //    case "_VISTA_ALEGRE":
            //        list.Add(new Territorio(false, img, zonas[4], name));
            //        zonas[4].InsertTerr(list[0]);
            //        break;
            //    case "_XAXIM":
            //        list.Add(new Territorio(false, img, zonas[5], name));
            //        zonas[5].InsertTerr(list[0]);
            //        break;
            //    default:
            //        break;
            //}

            return list;
        }
        public Territorio FindTerritorio(List<Territorio> territorios, string name)
        {
            return territorios.Where(t => t.GetName() == name).Single();
        }
        public void InsertAdjacent(List<Territorio> territorios)
        {
            var t = territorios;
            FindTerritorio(t, "aguaverde").InsertTerr(new Territorio[]{ FindTerritorio(territorios, "batel"), FindTerritorio(territorios, "portao"),
                FindTerritorio(territorios, "parolin"), FindTerritorio(territorios, "fazendinha"), FindTerritorio(territorios, "campocomprido"),
                FindTerritorio(territorios, "centro"), FindTerritorio(territorios, "reboucas")});
            // fazer para cada um dos territorios!!!!!!!!!!!
        }
    }

}
