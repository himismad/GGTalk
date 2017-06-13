using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESPlus.Rapid;
using System.Configuration;
using ESPlus.Application.Group.Server;
using ESPlus.Application.Group;
using ESPlus.Core;
using ESPlus.Application.CustomizeInfo;
using ESFramework.Boost.DynamicGroup.Server;

namespace GGMeeting.Server
{
    static class Program
    {
        static IRapidServerEngine RapidServerEngine = RapidEngineFactory.CreateServerEngine();
        static OMCS.Server.IMultimediaServer MultimediaServer;        
       
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ESPlus.GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                ESPlus.GlobalUtil.SetAuthorizedUser("FreeUser", "");

                DynamicGroupManager dynamicGroupManager = new DynamicGroupManager();//视频会议房间管理、即动态组管理
                Program.RapidServerEngine.HeartbeatTimeoutInSecs = int.Parse(ConfigurationManager.AppSettings["HeartbeatTimeoutInSecs"]);
                Program.RapidServerEngine.UseAsP2PServer = true;
                Program.RapidServerEngine.GroupManager = dynamicGroupManager;


                Program.RapidServerEngine.SecurityLogEnabled = false;
                CustomizeInfoHandler customizeInfoHandler = new CustomizeInfoHandler();
               
                DynamicGroupHandler groupHandler = new DynamicGroupHandler(); 

                ComplexCustomizeHandler complexHandler = new ComplexCustomizeHandler(customizeInfoHandler, groupHandler);
                Program.RapidServerEngine.Initialize(int.Parse(ConfigurationManager.AppSettings["Port"]), complexHandler);
                Program.RapidServerEngine.GroupController.GroupNotifyEnabled = true;
                Program.RapidServerEngine.UserManager.RelogonMode = ESFramework.Server.UserManagement.RelogonMode.IgnoreNew;               
                groupHandler.Initialize(Program.RapidServerEngine.UserManager, Program.RapidServerEngine.CustomizeController, dynamicGroupManager);

                #region OMCS 服务器设置
                OMCS.GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                OMCS.OMCSConfiguration config = new OMCS.OMCSConfiguration();

                //用于验证登录用户的帐密
                OMCS.Server.DefaultUserVerifier userVerifier = new OMCS.Server.DefaultUserVerifier();
                Program.MultimediaServer = OMCS.Server.MultimediaServerFactory.CreateMultimediaServer(int.Parse(ConfigurationManager.AppSettings["OMCS_Port"]), userVerifier, config, bool.Parse(ConfigurationManager.AppSettings["SecurityLogEnabled"]));

                #endregion

                OMCS.Server.ServerForm form = new OMCS.Server.ServerForm(Program.MultimediaServer);
                form.Text = "GGMeeting视频会议系统2015-服务器";
                Application.Run(form);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
