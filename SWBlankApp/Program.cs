using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using Microsoft.Office.Interop;
//using SolidWorks.Interop.swpublished;

namespace SWBlankApp
{
    class Program
    {

        //Microsoft.Office.Interop.MSProject

        
        //string[] args
        static void CreateSketch()
        {
            SldWorks swApp = new SldWorks();
            //Feature myFeature;
            ModelDoc2 swModel = default(ModelDoc2);
            //RefPlane myRefPlane;
            SketchManager swSkMgr = default(SketchManager);
            FeatureManager swFeMgr = default(FeatureManager);

            //Feature swFeat;
            //Sketch swSketch;
            int longstatus = 0;
            bool boolstatus = false;

            swApp.ResetUntitledCount(0, 0, 0);

            swModel = (ModelDoc2)swApp.NewDocument("C:\\Users\\nemati\\Documents\\Visual Studio 2015\\Projects\\SWBlankApp\\SWBlankApp\\PartTemplate.SLDPRT", 0, 0, 0);
            swApp.ActivateDoc2("Part1", false, ref longstatus);
            swModel = (ModelDoc2)swApp.ActiveDoc;


            swSkMgr = swModel.SketchManager;
            swFeMgr = swModel.FeatureManager;
            swSkMgr.InsertSketch(true);
            //swFeMgr.FeatureExtruRefSurface()
            boolstatus = swModel.Extension.SelectByID2("Top Plane", "PLANE", -0.0553489443349025, 0.00330468607538553, 0.0269617286188933, false, 0, null, 0);
            swModel.ClearSelection2(true);


            if (swModel == null)
            {
                swApp.SendMsgToUser2("Ridi.", (int)swMessageBoxIcon_e.swMbWarning, (int)swMessageBoxBtn_e.swMbOk);
                return;
            }

            int modelType = 0;
            modelType = swModel.GetType();

            if (modelType != (int)swDocumentTypes_e.swDocPART)
            {
                swApp.SendMsgToUser2("A part document must be active.", (int)swMessageBoxIcon_e.swMbWarning, (int)swMessageBoxBtn_e.swMbOk);
                return;
            }

            // Creating sample point
            SketchPoint skPoint = default(SketchPoint);
            skPoint = swSkMgr.CreatePoint(-100, 100, 0);


            // Creating sample arc
            SketchSegment skArc = default(SketchSegment);
            skArc = swSkMgr.Create3PointArc(0, 0, 0, 10, 10, 0, -10, 10, 0);


            // Creating sample circle
            SketchSegment skCircle = default(SketchSegment);
            skCircle = swSkMgr.CreateCircleByRadius(-20, 20, 0, 7.5);


            swSkMgr.InsertSketch(true);


            

            //swModel.SketchCircle();

            Console.WriteLine(swApp.Visible.ToString());

            Console.WriteLine(swApp.FrameWidth.ToString());

            //swApp.CreateNewWindow();

            swModel.SaveAs("C:\\Users\\nemati\\Documents\\Visual Studio 2015\\Projects\\SWBlankApp\\SWBlankApp\\SketchArc.SLDPRT");


            //swApp.

            swApp.ExitApp();

            //swApp = null;

            //swApp
        }

        static void CreateRevolve()
        {
            SldWorks swApp = new SldWorks();
            ModelDoc2 swModel;
            ModelDocExtension swModelDocExt;
            FeatureManager swFeatMgr;
            SelectionMgr swSelMgr;

            bool boolstatus;

            swModel = (ModelDoc2)swApp.NewDocument("C:\\Users\\nemati\\Documents\\Visual Studio 2015\\Projects\\SWBlankApp\\SWBlankApp\\PartTemplate.SLDPRT", 0, 0, 0);
            //swModel = (ModelDoc2)swApp.ActiveDoc;
            swModelDocExt = swModel.Extension;
            swSelMgr = (SelectionMgr)swModel.SelectionManager;

            boolstatus = swModelDocExt.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            boolstatus = swModelDocExt.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.InsertAxis2(true);


            boolstatus = swModelDocExt.SelectByID2("Top Plane", "PLANE", -0.08954836342753, 0.0004336873289503, 0.006720765739942, false, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.InsertSketch2(true);
            swModel.ClearSelection2(true);
            swModel.SketchRectangle(-0.05, -0.05, 0, 0, 0.1, 0, true);

            swModel.InsertSketch2(true);
            swModel.ShowNamedView2("*Trimetric", 8);

            boolstatus = swModelDocExt.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            boolstatus = swModelDocExt.SelectByID2("Axis1", "AXIS", 0, 0, 0, true, 4, null, (int)swSelectOption_e.swSelectOptionDefault);
            swFeatMgr = swModel.FeatureManager;

            swFeatMgr.FeatureRevolve2(true, true, false, false, false, false, 0, 0, 6.28318530718, 0, false,
            false, 0.01, 0.01, 0, 0, 0, true, true, true);


            swModel.SaveAs("C:\\Users\\nemati\\Documents\\Visual Studio 2015\\Projects\\SWBlankApp\\SWBlankApp\\FeatureRevolve.SLDPRT");

            swApp.ExitApp();


        }

        static void Main()
        {

            CreateSketch();
            CreateRevolve();
            

        }
        //public SldWorks swApp;
    }
}
