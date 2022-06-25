#define MyAppName "GestiPlus"
#define MyAppVersion "1.0.5"
#define MyAppURL "https://www.williamsorellana.rocks/gestiplus"
#define MyAppExeName "GestiPlus.exe"
#define MyInstallerName "GestiPlus Installer"

[Setup]
AppName={#MyAppName}
AppVersion={#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma2
SolidCompression=yes
OutputDir=Output
OutputBaseFilename={#MyInstallerName}
DisableProgramGroupPage=yes
WizardStyle=modern

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Azure.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Azure.Identity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Database.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Database.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.runtimeconfig.dev.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Security.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Security.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Session.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Session.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Utils.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\GestiPlus.Utils.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Krypton.Ribbon.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Krypton.Toolkit.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.Bcl.AsyncInterfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.Data.SqlClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.Data.Tools.Sql.BatchParser.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.Identity.Client.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.Identity.Client.Extensions.Msal.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.IdentityModel.JsonWebTokens.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.IdentityModel.Logging.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.IdentityModel.Protocols.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.IdentityModel.Protocols.OpenIdConnect.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.IdentityModel.Tokens.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Assessment.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Assessment.Types.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.ConnectionInfo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Dmf.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Dmf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.Assessment.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.Collector.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.CollectorEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.HadrData.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.HadrModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.RegisteredServers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.Sdk.Sfc.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.SqlScriptPublish.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.XEvent.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.XEventDbScoped.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.XEventDbScopedEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Management.XEventEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.PolicyEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.ServiceBrokerEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Smo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.Smo.Notebook.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.SmoExtended.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.SqlEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.SqlWmiManagement.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.SqlServer.WmiEnum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Microsoft.Win32.SystemEvents.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\NLog.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\NLog.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\Ribbon.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Configuration.ConfigurationManager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Data.OleDb.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Data.SqlClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Drawing.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.IdentityModel.Tokens.Jwt.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Management.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Runtime.Caching.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Security.AccessControl.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Security.Cryptography.ProtectedData.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Security.Permissions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\System.Windows.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\ref\*"; DestDir: "{app}\ref\"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\willian\source\repos\GestiPlus\GestiPlus\bin\Release\net5.0-windows\runtimes\*"; DestDir: "{app}\runtimes\"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent