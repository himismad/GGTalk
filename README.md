### 本项目为转载，源地址：http://www.cnblogs.com/justnow/p/3382160.html
作者：GGTalk
（最新版本：V6.0，2017.12.11 。即将推出Xamarin移动端版本，包括 Android 和 iOS）     

　　GGTalk开源即时通讯系统（简称GG）是QQ的高仿版，同时支持局域网和广域网，包括客户端（PC客户端、android移动端）、服务端、数据库。从2013年最初的GG1.0开放源码以来，到后来陆续增加了网盘功能、远程协助功能、离线文件功能、群聊功能、语音聊天功能、视频聊天功能、以及视讯录制功能、和增加了数据库。我想写一个类似汇总的文章，通过这篇文章，大家可以了解到GGTalk开源即时通讯系统的全貌和最新进展，以及关于一些常见问题的解答也汇总在这里。

　　言归正传，对我个人而言，我的目标并不是做一个QQ高仿版的玩具，而是希望做成一个能够真正使用的产品（这个过程还有很长的路要走），并持续维护下去。


一.GGTalk开源即时通讯系统已实现的功能
（01）注册、登录、查找用户、添加好友、好友列表。

（02）自拍头像。

（03）文字聊天、字体设置、GIF动态表情、窗口震动、截图、手写板、登录状态（在线、离开、忙碌、勿打扰、隐身）、输入提醒

（04）群功能：创建群、加入群、退出群、群聊天

（05）文件传送、文件夹传送（支持断点续传）

（06）语音视频聊天

（07）远程磁盘

（08）远程协助

（09）共享桌面（可以指定要共享的桌面区域）

（10）可靠的P2P

（11）网盘   

（12）离线消息

（13）离线文件

（14）托盘闪动：跟QQ完全一样，当接收到消息时，托盘会闪动对应好友的头像。点击头像，将弹出与好友的聊天框。

（15）最近联系人列表

（16）系统设置：开机自动启动、麦克风设备索引、摄像头设备索引，叉掉主窗口时关闭程序还是隐藏窗口。

（17）聊天记录：支持本地保存和服务器端保存两种方式。

（18）好友分组：新增/删除分组，修改分组名称，改变好友的所属分组。

（19）打开聊天窗口时，自动显示上次交谈的最后一句话。

（20）输入提醒：像QQ一样，当对方正在输入消息时，我这边的聊天框可以看到对方“正在输入”的提示。

（21）自动记录：GG2014会自动记录上次打开的主界面的位置、大小；最后一次打开的聊天窗口的大小；最后一次设定的字体的颜色、大小等。 

（22）主窗体靠边自动隐藏。

（23）录制视频聊天。

（24）支持数据库（SqlServer 2000/2005/2008、MySQL），并可以通过配置在真实数据库和虚拟数据库之间自由切换。 

（25）语音视频设备测试   

（26）聊天消息加密

（27）系统通知

 

二.开发环境及GGTalk即时通讯源码说明
1. 服务端和PC端 ：VS2010 ，开发语言：C#， .NET Framework 版本： 2.0 

2. android移动端：android studio 1.3.2 ，gradle 1.3 

3. 部署PC客户端时，客户端机器还需要安装 VC++ runtime（2008、2010、2013）。

4. 若是要开始研究GG的源码，客户端和服务端的入口分别是：

（1）客户端：请特别关注 MainFormPartial.cs 这个文件，客户端接收到的消息几乎都是在这个文件中处理的；GlobalUserCache类用于缓存所有的用户信息、群组信息、包括本地持久化这些信息，以及根据版本号自动更新这些信息。

（2）服务端：请特别关注 CustomizeHandler.cs 这个文件，服务端接收到的消息几乎都是在这个文件中处理的；GlobalCache类用于缓存所有的用户信息、群组信息，并与真实/虚拟数据库进行交互。

   

三.相关说明
1.如果要将GGTalk开源即时通讯系统部署到广域网，则可以在服务端的配置文件中设置监听的端口；而在客户端的配置文件中，则可以指定服务器的IP和Port。

2.麦克风、摄像头的选择可在客户端系统设置窗口（SystemSettingForm）中指定。

3.语音视频：也有很多朋友问语音视频设备的工作怎么不正常，或者语音视频不流畅，这个可以直接参考OMCS官方文档：摄像头、麦克风、扬声器、设备测试 、带宽要求。

4.特别说明一下：GG项目中，只要是我写的代码，全部都放出来了。拜托喜欢每一个dll都有源码的朋友不要再问我要其它的源码了：）

   

四.源码版本记录
2013.08.07  --  V1.0， 登录、好友列表、文字聊天、文件传送、文件夹传送

2013.09.02  --  V1.8， 语音视频聊天

2013.09.23  --  V2.0， 网盘、远程磁盘

2013.11.05  --  V2.4， 远程协助、共享桌面

2014.04.15  --  V3.0， 注册、加好友、加入群、群聊

2014.05.16  --  V3.2， 离线消息、离线文件

2014.05.28  --  V3.4， 系统设置、最近联系人

2014.06.30  --  V3.5， 自拍头像、修改密码、删除好友

2014.08.06  --  V3.6， 语音消息、语音留言 

2014.09.16  --  V3.7， 优化视频聊天 

2014.11.06  --  V4.0， 聊天记录、好友分组、登录状态、GIF动态表情

2014.12.31  --  V4.1， 托盘闪动消息提醒、公开JustLib源码。

2015.03.25  --  V4.2， 主窗体靠边自动隐藏

2015.06.17  --  V4.3， 视频聊天全过程录制，生成标准的MP4文件。

2015.09.02  --  V4.4， 增加对SqlServer数据库的支持，并可以通过配置在真实数据库和虚拟数据库之间自由切换。 增加语音视频设备测试功能。

2015.09.02  --  V4.4， 客户端增加Android移动端版本。

2016.01.20  --  V4.5， 加密聊天消息，让通信更安全！语音视频优化，视频聊天更流畅！

2016.05.30  --  V5.1， 增加系统通知功能，并支持与Web集成！

2016.12.06  --  V5.5， 增加对MySQL数据库的支持！

 2017.12.11  --  V6.0， 增加Xamarin移动端，包括 Android 和 iOS！

 

五.GG截图
0. android 移动端

           

1.登录框

       

2.主窗体、最近联系人

           

3.聊天窗口                                                                                 

          

4.视频会话邀请、视频会话    （2015.06.17 增加视频聊天录制功能） 

                  

5.磁盘访问请求、进入远程磁盘

             

6.远程磁盘操作

      

7.网盘

      

8.远程协助

            

9.共享桌面（指定了QQ影音播放器的区域作为共享区域）

      

10.注册：

          

11.添加好友：

      

12.加入群：

     

13.群聊天：

     

14.离线消息：

      

15.发送离线文件：

      

16.离线文件发送完成、接收完成：

　　 

17.系统设置：

　　     

18.自拍头像：

      

19.使用自拍头像：

      

20.聊天记录：

　　

21.好友分组:

　　

22.正在输入：

　　

 

六.最新源码下载
1.GGTalk服务端和PC端源码    
      源码下载：GGTalk-V6.0源码.rar     网盘下载更快

 　 部署下载：GGTalk V6.0 可直接部署版本    网盘下载更快

    （压缩包中有 《部署说明.txt》 和 创建数据库的脚本 《GGTalk.sql》）

      注：我的GGTalk使用VS2010编译生成的GGTalk.exe文件，这个文件有时会被新毒霸报是病毒，也许是编译生成的GGTalk.exe文件中有某段数据与病毒库中的某特征符合吧，大家帮我看看源码中有那段代码像是病毒了：）

部署说明：      

1.当前版本服务端默认配置为内存虚拟数据库版本，不需要安装数据库。

2.将GGTalk.Server文件夹拷贝到服务器上，运行GGTalk.Server.exe。

3.修改客户端配置文件GGTalk.exe.config中ServerIP配置项的值为服务器的IP。

4.运行客户端，注册帐号登录试用。

5.内置测试帐号为 10000，10001，10002，10003，10004；密码都是 1。 

6.若要测试android移动端，请先修改安卓源码中服务器的IP和端口，然后重新编译生成apk。 

如果需要使用真实的物理数据库，则需按下列步骤进行：

1. 在SqlServer 2000/2005/2008 中新建数据库GGTalk，然后在该库中执行 SqlServer.sql 文件中的脚本以创建所需表。

    (如果要使用MySQL数据库，则使用MySQL.sql脚本)

2. 打开服务端的配置文件GGTalk.Server.exe.config

（1）修改 UseVirtualDB 配置项的值为false。

（2）修改 DBType 为 SqlServer 或 MySQL。

（3）修改 DBIP 配置项的值为数据库的IP地址。

（4）修改 SaPwd 配置项的值为数据库管理员sa的密码。

3.修改客户端配置文件GGTalk.exe.config中ServerIP配置项的值为服务器的IP。

4.运行客户端，注册帐号登录试用。

2.GGTalk即时通讯系统安卓源码     
      GG安卓版本已实现如下功能：

（1）登录服务端

（2）文字聊天，表情图片,消息提醒

（3）好友列表

（4）显示好友在线状态

（5）文件传输

     （若要和PC端联合测试，请关闭PC端那边的聊天消息加密功能：将PC客户端项目的GlobalResourceManager类的 des3Encryption 成员赋值为 null 即可！）

     说明：本安卓demo属于入门级水平，目的是为了展示与PC打通的基本实现。若要将GG安卓版本的源码用于正式项目中，建议先对其进行重构，或者敬请等候后续更完善的版本分享给大家！

 

      

________________________________________________________________________

 

几句题外话：虽然就如何将GG发展为一个有商业价值的产品，我还没有很清晰明确的思路，但是从GG发布以来，通过GG认识了一些朋友，也接了一些小单子，赚了一点小钱。有了一点甜头，目前和2、3个好朋友一起做做小项目也是不错的，这未尝不是一条养家糊口之路了？呵呵。


如果你觉得还不错，请粉我，顺便再顶一下啊