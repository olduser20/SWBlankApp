using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
//using SolidWorks.Interop.swpublished;

namespace SWBlankApp
{
    class Program
    {
        //string[] args
        static void Main()
        {
            SldWorks swApp = new SldWorks();
            //Feature myFeature;
            ModelDoc2 swModel =default(ModelDoc2);
            //RefPlane myRefPlane;
            SketchManager swSkMgr=default(SketchManager);
            FeatureManager swFeMgr = default(FeatureManager);

            //Feature swFeat;
            //Sketch swSketch;
            int longstatus = 0;
            bool boolstatus = false;

            swApp.ResetUntitledCount(0, 0, 0);

            swModel = (ModelDoc2)swApp.NewDocument("C:\\Users\\nemati\\Documents\\Visual Studio 2015\\Projects\\SWBlankApp\\SWBlankApp\\PartTemplate.SLDPRT", 0,0,0);
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
                swApp.SendMsgToUser2("Ridi.",(int)swMessageBoxIcon_e.swMbWarning ,(int)swMessageBoxBtn_e.swMbOk);
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


            Feature feRevolve = default(Feature);
            
            feRevolve = swFeMgr.FeatureRevolve(90, false, 0, 0, 0, false, false, false);

            
            //swModel.SketchCircle();

            Console.WriteLine(swApp.Visible.ToString());

            Console.WriteLine(swApp.FrameWidth.ToString());

            //swApp.CreateNewWindow();

            swModel.SaveAs("C:\\Users\\nemati\\Documents\\Visual Studio 2015\\Projects\\SWBlankApp\\SWBlankApp\\PartModefied.SLDPRT");
            

            //swApp.

            swApp.ExitApp();

            //swApp = null;

            //swApp

            

        }
        //public SldWorks swApp;
    }
}
