using System.Runtime.InteropServices;

namespace CincoVertice.WinAPI.Libs
{
    public class Advapi32
    {
        /// <summary>
        /// The LogonUser function attempts to log a user on to the local computer.
        /// The local computer is the computer from which LogonUser was called.
        /// You cannot use LogonUser to log on to a remote computer.
        /// You specify the user with a user name and domain and authenticate the user with a plaintext password. If the function succeeds, you receive a handle to a token that represents the logged-on user. You can then use this token handle to impersonate the specified user or, in most cases, to create a process that runs in the context of the specified user.
        /// </summary>
        /// <param name="pszUserName">This is the name of the user account to log on to. If you use the user principal name (UPN) format, User@DNSDomainName, the lpszDomain parameter must be NULL.</param>
        /// <param name="pszDomain">Specifies the name of the domain or server whose account database contains the lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the function validates the account by using only the local account database.</param>
        /// <param name="pszPassword">Specifies the plaintext password for the user account specified by lpszUsername. When you have finished using the password, clear the password from memory by calling the SecureZeroMemory function.</param>
        /// <param name="dwLogonType">The type of logon operation to perform.</param>
        /// <param name="dwLogonProvider">Specifies the logon provider.</param>
        /// <param name="phToken">A pointer to a handle variable that receives a handle to a token that represents the specified user.</param>
        /// <returns>If the function succeeds, the function returns nonzero.</returns>
        [DllImport("advapi32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUser(
            [MarshalAs(UnmanagedType.LPStr)] string pszUserName,
            [MarshalAs(UnmanagedType.LPStr)] string pszDomain,
            [MarshalAs(UnmanagedType.LPStr)] string pszPassword,
            LogonType dwLogonType,
            LogonProvider dwLogonProvider,
            ref nint phToken);

        /// <summary>
        /// The type of logon operation to perform.
        /// </summary>
        public enum LogonType : uint
        {
            /// <summary>
            /// This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, remote shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore, it is inappropriate for some client/server applications, such as a mail server.
            /// </summary>
            LOGON32_LOGON_INTERACTIVE = 2,

            /// <summary>
            /// This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not cache credentials for this logon type.
            /// </summary>
            LOGON32_LOGON_NETWORK = 3,

            /// <summary>
            /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention. This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or web servers.
            /// </summary>
            LOGON32_LOGON_BATCH = 4,

            /// <summary>
            /// Indicates a service-type logon. The account provided must have the service privilege enabled.
            /// </summary>
            LOGON32_LOGON_SERVICE = 5,

            /// <summary>
            /// GINAs are no longer supported.
            /// Windows Server 2003 and Windows XP:  This logon type is for GINA DLLs that log on users who will be interactively using the computer.This logon type can generate a unique audit record that shows when the workstation was unlocked.
            /// </summary>
            LOGON32_LOGON_UNLOCK = 7,

            /// <summary>
            /// This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network servers while impersonating the client. A server can accept plaintext credentials from a client, call LogonUser, verify that the user can access the system across the network, and still communicate with other servers.
            /// </summary>
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

            /// <summary>
            /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has the same local identifier but uses different credentials for other network connections.
            /// This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
            /// </summary>
            LOGON32_LOGON_NEW_CREDENTIALS = 9,
        }

        /// <summary>
        /// Specifies the logon provider.
        /// </summary>
        public enum LogonProvider : uint
        {
            /// <summary>
            /// Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the domain name and the user name is not in UPN format. In this case, the default provider is NTLM.
            /// </summary>
            LOGON32_PROVIDER_DEFAULT = 0,
        }
    }
}
