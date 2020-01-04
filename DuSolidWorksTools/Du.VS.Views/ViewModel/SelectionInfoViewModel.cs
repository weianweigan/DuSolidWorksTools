using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Du.ViewModel
{
    public class SelectionInfoViewModel:ViewModelBase
    {
        #region 字段
        private SldWorks swApp;
        #endregion
        #region 构造函数
        public SelectionInfoViewModel()
        { }
        #endregion
        #region 界面属性
        private object _SelectedSoliWorksObj;
        public object SelectedSoliWorksObj
        {
            get { return _SelectedSoliWorksObj; }
            set { _SelectedSoliWorksObj = value;
                RaisePropertyChanged("SelectedSoliWorksObj");
            }
        }

        private string _SelectedText;
        public string SelectedText
        {
            get { return _SelectedText; }
            set { _SelectedText = value;RaisePropertyChanged("SelectedText"); }
        }
        #endregion

        #region Command
        private RelayCommand _GetSelectedObjectCommand;

        public RelayCommand GetSelectedObjectCommand
        {
            get
            {
                if (_GetSelectedObjectCommand == null)
                {
                    _GetSelectedObjectCommand = new RelayCommand(GetSelectedObjectClick);
                } 
                return _GetSelectedObjectCommand; }
            set { _GetSelectedObjectCommand = value; }
        }
        /// <summary>
        /// 获取选中的对象
        /// </summary>
        private void GetSelectedObjectClick()
        {
            //if (swApp == null )
            //{
                //swApp = (SldWorks)Du.Core.DuSolidWorks.GetActiveswApp();
            //}
            if (swApp != null)
            {
                ModelDoc2 swModel = swApp.ActiveDoc;
                if (swModel != null)
                {
                    int Count = swModel.ISelectionManager.GetSelectedObjectCount();
                    if (Count == 0)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("当前未有选中的SolidWorks对象");
                    }
                     swSelectType_e swSeleType = (swSelectType_e)swModel.ISelectionManager.GetSelectedObjectType3(1, -1);
                    SelectedText = "SolidWorks.Interop.swconst.swSelectType_e."+ swSeleType.ToString();
                    object swObj = swModel.ISelectionManager.GetSelectedObject6(1, -1);
                    if (swObj != null)
                    {
                        switch (swSeleType)
                        {

                            case swSelectType_e.swSelNOTHING:
                                break;

                            #region 几何信息
                            case swSelectType_e.swSelEDGES:
                                break;
                            case swSelectType_e.swSelFACES:
                                break;
                            case swSelectType_e.swSelVERTICES:
                                break;
                            #endregion

                            #region 参考几何体
                            case swSelectType_e.swSelDATUMPLANES:
                                break;
                            case swSelectType_e.swSelDATUMAXES:
                                break;
                            case swSelectType_e.swSelDATUMPOINTS:
                                break;
                            case swSelectType_e.swSelOLEITEMS:
                                break;
                            case swSelectType_e.swSelATTRIBUTES:
                                break;
                            case swSelectType_e.swSelBODYFEATURES:
                                break;
                            case swSelectType_e.swSelREFCURVES:
                                break;

                            case swSelectType_e.swSelHELIX:
                                break;
                            //case swSelectType_e.swSelREFERENCECURVES:
                            //    break;
                            case swSelectType_e.swSelREFSURFACES:
                                break;
                            case swSelectType_e.swSelCENTERMARKS:
                                break;
                            case swSelectType_e.swSelINCONTEXTFEAT:
                                break;
                            #endregion

                            #region 草图几何体
                            case swSelectType_e.swSelSKETCHES:
                                break;
                            case swSelectType_e.swSelSKETCHSEGS:
                                break;
                            case swSelectType_e.swSelSKETCHPOINTS:
                                break;
                            case swSelectType_e.swSelEXTSKETCHSEGS:
                                break;
                            case swSelectType_e.swSelEXTSKETCHPOINTS:
                                break;
                            case swSelectType_e.swSelBREAKLINES:
                                break;
                            case swSelectType_e.swSelINCONTEXTFEATS:
                                break;

                            case swSelectType_e.swSelSKETCHTEXT:
                                break;
                            #endregion
                            #region 工程图和标注对象
                            case swSelectType_e.swSelDRAWINGVIEWS:
                                break;
                            case swSelectType_e.swSelGTOLS:
                                break;
                            case swSelectType_e.swSelDIMENSIONS:
                                break;
                            case swSelectType_e.swSelNOTES:
                                break;
                            case swSelectType_e.swSelSECTIONLINES:
                                break;
                            case swSelectType_e.swSelDETAILCIRCLES:
                                break;
                            case swSelectType_e.swSelSECTIONTEXT:
                                break;
                            case swSelectType_e.swSelSHEETS:
                                break;
                            case swSelectType_e.swSelSFSYMBOLS:
                                break;
                            case swSelectType_e.swSelDATUMTAGS:
                                break;
                            #endregion

                            #region 零件和配合对象
                            case swSelectType_e.swSelCOMPONENTS:
                                break;
                            case swSelectType_e.swSelMATES:
                                break;
                            case swSelectType_e.swSelMATEGROUP:
                                break;
                            case swSelectType_e.swSelMATEGROUPS:
                                break;
                            #endregion

                            #region 特征对象
                            case swSelectType_e.swSelCOMPPATTERN:
                                break;
                            #endregion


                            case swSelectType_e.swSelWELDS:
                                break;
                            case swSelectType_e.swSelCTHREADS:
                                break;
                            case swSelectType_e.swSelDTMTARGS:
                                break;
                            case swSelectType_e.swSelPOINTREFS:
                                break;
                            case swSelectType_e.swSelDCABINETS:
                                break;
                            case swSelectType_e.swSelEXPLVIEWS:
                                break;
                            case swSelectType_e.swSelEXPLSTEPS:
                                break;
                            case swSelectType_e.swSelEXPLLINES:
                                break;
                            case swSelectType_e.swSelSILHOUETTES:
                                break;
                            case swSelectType_e.swSelCONFIGURATIONS:
                                break;
                            case swSelectType_e.swSelOBJHANDLES:
                                break;
                            case swSelectType_e.swSelARROWS:
                                break;
                            case swSelectType_e.swSelZONES:
                                break;
                            case swSelectType_e.swSelREFEDGES:
                                break;
                            case swSelectType_e.swSelREFFACES:
                                break;
                            case swSelectType_e.swSelREFSILHOUETTE:
                                break;
                            case swSelectType_e.swSelBOMS:
                                break;
                            case swSelectType_e.swSelEQNFOLDER:
                                break;
                            case swSelectType_e.swSelSKETCHHATCH:
                                break;
                            case swSelectType_e.swSelIMPORTFOLDER:
                                break;
                            case swSelectType_e.swSelVIEWERHYPERLINK:
                                break;
                            case swSelectType_e.swSelMIDPOINTS:
                                break;
                            case swSelectType_e.swSelCUSTOMSYMBOLS:
                                break;
                            case swSelectType_e.swSelCOORDSYS:
                                break;
                            case swSelectType_e.swSelDATUMLINES:
                                break;
                            case swSelectType_e.swSelROUTECURVES:
                                break;
                            case swSelectType_e.swSelBOMTEMPS:
                                break;
                            case swSelectType_e.swSelROUTEPOINTS:
                                break;
                            case swSelectType_e.swSelCONNECTIONPOINTS:
                                break;
                            case swSelectType_e.swSelROUTESWEEPS:
                                break;
                            case swSelectType_e.swSelPOSGROUP:
                                break;
                            case swSelectType_e.swSelBROWSERITEM:
                                break;
                            case swSelectType_e.swSelFABRICATEDROUTE:
                                break;
                            case swSelectType_e.swSelSKETCHPOINTFEAT:
                                break;
                            case swSelectType_e.swSelEMPTYSPACE:
                                break;
                            //case swSelectType_e.swSelCOMPSDONTOVERRIDE:
                            //    break;
                            case swSelectType_e.swSelLIGHTS:
                                break;
                            case swSelectType_e.swSelWIREBODIES:
                                break;
                            case swSelectType_e.swSelSURFACEBODIES:
                                break;
                            case swSelectType_e.swSelSOLIDBODIES:
                                break;
                            case swSelectType_e.swSelFRAMEPOINT:
                                break;
                            case swSelectType_e.swSelSURFBODIESFIRST:
                                break;
                            case swSelectType_e.swSelMANIPULATORS:
                                break;
                            case swSelectType_e.swSelPICTUREBODIES:
                                break;
                            case swSelectType_e.swSelSOLIDBODIESFIRST:
                                break;
                            case swSelectType_e.swSelHOLESERIES:
                                break;
                            case swSelectType_e.swSelLEADERS:
                                break;
                            case swSelectType_e.swSelSKETCHBITMAP:
                                break;
                            case swSelectType_e.swSelDOWELSYMS:
                                break;
                            case swSelectType_e.swSelEXTSKETCHTEXT:
                                break;
                            case swSelectType_e.swSelBLOCKINST:
                                break;
                            case swSelectType_e.swSelFTRFOLDER:
                                break;
                            case swSelectType_e.swSelSKETCHREGION:
                                break;
                            case swSelectType_e.swSelSKETCHCONTOUR:
                                break;
                            case swSelectType_e.swSelBOMFEATURES:
                                break;
                            case swSelectType_e.swSelANNOTATIONTABLES:
                                break;
                            case swSelectType_e.swSelBLOCKDEF:
                                break;
                            case swSelectType_e.swSelCENTERMARKSYMS:
                                break;
                            case swSelectType_e.swSelSIMULATION:
                                break;
                            case swSelectType_e.swSelSIMELEMENT:
                                break;
                            case swSelectType_e.swSelCENTERLINES:
                                break;
                            case swSelectType_e.swSelHOLETABLEFEATS:
                                break;
                            case swSelectType_e.swSelHOLETABLEAXES:
                                break;
                            case swSelectType_e.swSelWELDMENT:
                                break;
                            case swSelectType_e.swSelSUBWELDFOLDER:
                                break;
                            case swSelectType_e.swSelEXCLUDEMANIPULATORS:
                                break;
                            case swSelectType_e.swSelREVISIONTABLE:
                                break;
                            case swSelectType_e.swSelSUBSKETCHINST:
                                break;
                            case swSelectType_e.swSelWELDMENTTABLEFEATS:
                                break;
                            case swSelectType_e.swSelBODYFOLDER:
                                break;
                            case swSelectType_e.swSelREVISIONTABLEFEAT:
                                break;
                            case swSelectType_e.swSelSUBATOMFOLDER:
                                break;
                            case swSelectType_e.swSelWELDBEADS:
                                break;
                            case swSelectType_e.swSelEMBEDLINKDOC:
                                break;
                            case swSelectType_e.swSelJOURNAL:
                                break;
                            case swSelectType_e.swSelDOCSFOLDER:
                                break;
                            case swSelectType_e.swSelCOMMENTSFOLDER:
                                break;
                            case swSelectType_e.swSelCOMMENT:
                                break;
                            case swSelectType_e.swSelSWIFTANNOTATIONS:
                                break;
                            case swSelectType_e.swSelSWIFTFEATURES:
                                break;
                            case swSelectType_e.swSelCAMERAS:
                                break;
                            case swSelectType_e.swSelMATESUPPLEMENT:
                                break;
                            case swSelectType_e.swSelANNOTATIONVIEW:
                                break;
                            case swSelectType_e.swSelGENERALTABLEFEAT:
                                break;
                            case swSelectType_e.swSelDISPLAYSTATE:
                                break;
                            case swSelectType_e.swSelSUBSKETCHDEF:
                                break;
                            case swSelectType_e.swSelSWIFTSCHEMA:
                                break;
                            case swSelectType_e.swSelTITLEBLOCK:
                                break;
                            case swSelectType_e.swSelTITLEBLOCKTABLEFEAT:
                                break;
                            case swSelectType_e.swSelOBJGROUP:
                                break;
                            case swSelectType_e.swSelPLANESECTIONS:
                                break;
                            case swSelectType_e.swSelCOSMETICWELDS:
                                break;
                            case swSelectType_e.SwSelMAGNETICLINES:
                                break;
                            case swSelectType_e.swSelPUNCHTABLEFEATS:
                                break;
                            case swSelectType_e.swSelREVISIONCLOUDS:
                                break;
                            case swSelectType_e.swSelBorder:
                                break;
                            case swSelectType_e.swSelSELECTIONSETFOLDER:
                                break;
                            case swSelectType_e.swSelSELECTIONSETNODE:
                                break;
                            case swSelectType_e.swSelEVERYTHING:
                                break;
                            case swSelectType_e.swSelLOCATIONS:
                                break;
                            case swSelectType_e.swSelUNSUPPORTED:
                                break;
                            default:
                                break;
                        }
                        SelectedSoliWorksObj = swObj;
                    }
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("当前未有打开的SolidWorks文档");
                }
            }
            else
            {
                    Xceed.Wpf.Toolkit.MessageBox.Show("当前未有打开的SolidWorks");
            }
        }
        #endregion

        #region 私有方法

        #endregion
        #region 公有方法

        #endregion

    }
}
