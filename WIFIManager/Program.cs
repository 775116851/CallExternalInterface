using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;

namespace WIFIManager
{
    class Program
    {
        //无线网络设备状态
        public enum WLAN_INTERFACE_STATE
        {
            wlan_interface_state_not_ready = 0,
            wlan_interface_state_connected = 1,
            wlan_interface_state_ad_hoc_network_formed = 2,
            wlan_interface_state_disconnecting = 3,
            wlan_interface_state_disconnected = 4,
            wlan_interface_state_associating = 5,
            wlan_interface_state_discovering = 6,
            wlan_interface_state_authenticating = 7
        }
        //无线网络设备信息
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_INTERFACE_INFO
        {
            /// <summary>
            /// 设备GUID
            /// </summary>
            public Guid InterfaceGuid;
            /// <summary>
            /// 设备描述
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strInterfaceDescription;
            /// <summary>
            /// 获取无线设备描述
            /// </summary>
            public string StrInterfaceDescription
            {
                get { return strInterfaceDescription; }
            }
            /// <summary>
            /// 设备状态
            /// </summary>
            public WLAN_INTERFACE_STATE isState;
        }
        //无线网络设备信息列表
        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_INTERFACE_INFO_LIST
        {
            /// <summary>
            /// 无线设备数量
            /// </summary>
            public Int32 dwNumberOfItems;
            /// <summary>
            /// 无线设备下标
            /// </summary>
            public Int32 dwIndex;
            /// <summary>
            /// 无线设备信息列表
            /// </summary>
            public WLAN_INTERFACE_INFO[] InterfaceInfo;
            public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
            {
                dwNumberOfItems = Marshal.ReadInt32(pList, 0);
                dwIndex = Marshal.ReadInt32(pList, 4);
                InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberOfItems];
                for (int i = 0; i < dwNumberOfItems; i++)
                {
                    IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * 532) + 8);
                    WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
                    wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
                    InterfaceInfo[i] = wii;
                }
            }
        }
        //SSID
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DOT11_SSID
        {
            /// <summary>
            /// SSID长度
            /// </summary>
            public uint uSSIDLength;
            /// <summary>
            /// SSID
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string ucSSID;
        }
        //BSS类型
        public enum DOT11_BSS_TYPE
        {
            /// <summary>
            /// 指定BSS网络为基础架构网络。
            /// </summary>
            dot11_BSS_type_infrastructure = 1,
            /// <summary>
            /// 指定为独立的BSS（IBSS）网络。
            /// </summary>
            dot11_BSS_type_independent = 2,
            /// <summary>
            /// 以上两者都可以。
            /// </summary>
            dot11_BSS_type_any = 3,
        }
        //可见网络信息
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_AVAILABLE_NETWORK
        {
            /// <summary>
            /// 连接配置名称
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strProfileName;
            public string StrProfileName
            {
                get { return strProfileName; }
            }
            /// <summary>
            /// SSID
            /// </summary>
            public DOT11_SSID dot11Ssid;
            public string Dot11Ssid
            {
                get
                {
                    string value = string.Format("SSID:{0} 信号强度:{1} 配置文件名称:{2} 是否加密:{3} 默认身份验证:{4} 默认加密算法:{5}",
                        dot11Ssid.ucSSID,
                        wlanSignalQuality,
                        string.IsNullOrEmpty(strProfileName) ? "配置文件隐藏" : strProfileName,
                        bSecurityEnabled,
                        dot11DefaultAuthAlgorithm.ToString(),
                        dot11DefaultCipherAlgorithm.ToString()
                        );
                    return value;
                }
            }
            /// <summary>
            /// BSS类型
            /// </summary>
            public DOT11_BSS_TYPE dot11BssType;
            /// <summary>
            /// BSSIDs的数量
            /// </summary>
            public uint uNumberOfBssids;
            /// <summary>
            /// 是否可连接
            /// </summary>
            public bool bNetworkConnectable;
            /// <summary>
            /// 不可被连接的原因
            /// </summary>
            public uint wlanNotConnectableReason;
            /// <summary>
            /// 可用网络所支持的PHY（物理层）类型数量
            /// </summary>
            public uint uNumberOfPhyTypes;
            /// <summary>
            /// 可连接网络所支持的PHY类型的数组,如有超过8个的，这里就不要设置它的大小，并且下面的bMorePhyTypes需设置为TRUE
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public DOT11_PHY_TYPE[] dot11PhyTypes;
            /// <summary>
            /// 指定支持的PHY类型数量大于WLAN_MAX_PHY_TYPE_NUMBER设定的值
            /// </summary>
            public bool bMorePhyTypes;
            /// <summary>
            /// 信号强度
            /// </summary>
            public uint wlanSignalQuality;
            /// <summary>
            /// 指示网络是否加密
            /// </summary>
            public bool bSecurityEnabled;
            /// <summary>
            /// 第一次连接网络所使用的默认认证算法
            /// </summary>
            public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;
            /// <summary>
            /// 连接到网络所使用的默认加密算法
            /// </summary>
            public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;
            /// <summary>
            /// 网络的各种标志
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// 备用字段，必须设置为NULL
            /// </summary>
            public uint dwReserved;
        }
        //可见网络信息列表
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_AVAILABLE_NETWORK_LIST
        {
            /// <summary>
            /// 可见网络数量
            /// </summary>
            public uint dwNumberOfItems;
            /// <summary>
            /// 可见网络下标
            /// </summary>
            public uint dwIndex;
            /// <summary>
            /// 可见网络
            /// </summary>    
            public WLAN_AVAILABLE_NETWORK[] wlanAvailableNetwork;
            public WLAN_AVAILABLE_NETWORK_LIST(IntPtr ppAvailableNetworkList)
            {
                dwNumberOfItems = (uint)Marshal.ReadInt32(ppAvailableNetworkList);
                dwIndex = (uint)Marshal.ReadInt32(ppAvailableNetworkList, 4);
                wlanAvailableNetwork = new WLAN_AVAILABLE_NETWORK[dwNumberOfItems];
                for (int i = 0; i < dwNumberOfItems; i++)
                {
                    IntPtr pWlanAvailableNetwork = new IntPtr(ppAvailableNetworkList.ToInt32() + i * Marshal.SizeOf(typeof(WLAN_AVAILABLE_NETWORK)) + 8);
                    wlanAvailableNetwork[i] = (WLAN_AVAILABLE_NETWORK)Marshal.PtrToStructure(pWlanAvailableNetwork, typeof(WLAN_AVAILABLE_NETWORK));
                }
            }
        }

        //PHY类型
        public enum DOT11_PHY_TYPE
        {
            /// <summary>
            /// 指定一个未知或者未初始化的PHY类型。
            /// </summary>
            dot11_phy_type_unknown = 1,
            /// <summary>
            /// 指定任意PHY类型。
            /// </summary>
            dot11_phy_type_any,
            /// <summary>
            /// 指示PHY类型是跳频PHY类型，蓝牙设备可以使用跳频技术或者自适应的跳频设备。
            /// </summary>
            dot11_phy_type_fhss,
            /// <summary>
            /// 指定为支持展频技术的PHY。
            /// </summary>
            dot11_phy_type_dsss,
            /// <summary>
            /// 指定为支持红外基频的PHY。
            /// </summary>
            dot11_phy_type_irbaseband,
            /// <summary>
            /// 指定为正交频分复用（OFDM）的PHY。 802.11a设备可以采用OFDM。
            /// </summary>
            dot11_phy_type_ofdm,
            /// <summary>
            /// 指定为高速率扩展频谱（HRDSSS）PHY。
            /// </summary>
            dot11_phy_type_hrdsss,
            /// <summary>
            /// 指定为增强速率物理层（ERP），802.11g设备可以使用ERP。
            /// </summary>
            dot11_phy_type_erp,
            /// <summary>
            /// 指定为802.11n物理层类型。
            /// </summary>
            dot11_phy_type_ht,
            /// <summary>
            /// 指定范围的开始用以定义PHY类型是一个独立硬件供应商开发的。
            /// </summary>
            dot11_phy_type_IHV_start,
            /// <summary>
            /// 指定范围的结尾用以定义PHY类型是一个独立硬件供应商开发的。
            /// </summary>
            dot11_phy_type_IHV_end
        }
        //授权算法
        public enum DOT11_AUTH_ALGORITHM
        {
            DOT11_AUTH_ALGO_80211_OPEN = 1,
            DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,
            DOT11_AUTH_ALGO_WPA = 3,
            DOT11_AUTH_ALGO_WPA_PSK = 4,
            DOT11_AUTH_ALGO_WPA_NONE = 5,
            DOT11_AUTH_ALGO_RSNA = 6,
            DOT11_AUTH_ALGO_RSNA_PSK = 7,
            DOT11_AUTH_ALGO_IHV_START = -2147483648,
            DOT11_AUTH_ALGO_IHV_END = -1,
        }
        //加密算法
        public enum DOT11_CIPHER_ALGORITHM
        {
            DOT11_CIPHER_ALGO_NONE = 0,
            DOT11_CIPHER_ALGO_WEP40 = 1,
            DOT11_CIPHER_ALGO_TKIP = 2,
            DOT11_CIPHER_ALGO_CCMP = 4,
            DOT11_CIPHER_ALGO_WEP104 = 5,
            DOT11_CIPHER_ALGO_WPA_USE_GROUP = 256,
            DOT11_CIPHER_ALGO_RSN_USE_GROUP = 256,
            DOT11_CIPHER_ALGO_WEP = 257,
            DOT11_CIPHER_ALGO_IHV_START = -2147483648,
            DOT11_CIPHER_ALGO_IHV_END = -1,
        }
        //打开无线连接句柄
        [DllImport("Wlanapi", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern uint WlanOpenHandle(
            uint dwClientVersion, IntPtr pReserved,
            [Out] out uint pdwNegotiatedVersion,
            ref IntPtr ClientHandle);
        //关闭句柄
        [DllImport("Wlanapi", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern uint WlanCloseHandle(
            [In] IntPtr hClientHandle,
            IntPtr pReserved);
        //列举无线网络适配器
        [DllImport("Wlanapi", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern uint WlanEnumInterfaces(
            [In] IntPtr hClientHandle,
            IntPtr pReserved,
            ref IntPtr ppInterfaceList);
        //释放内存
        [DllImport("Wlanapi", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern void WlanFreeMemory([In] IntPtr pMemory);

        //获得可用无线网络
        [DllImport("Wlanapi", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern uint WlanGetAvailableNetworkList(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            uint dwFlags,
            IntPtr pReserved,
            ref IntPtr ppAvailableNetworkList);

        static void Main(string[] args)
        {
            //1.首先回去句柄
            uint serviceVersion = 0;
            IntPtr handle = IntPtr.Zero;
            uint result = WlanOpenHandle(2, IntPtr.Zero, out serviceVersion, ref handle);

            if (result == 0)
            {
                try
                {
                    //2.列举无线设备，如果你有几个无线网卡，这里就需要选择使用哪一个无线网卡设备
                    IntPtr ppInterfaceList = IntPtr.Zero;
                    WLAN_INTERFACE_INFO_LIST interfaceList;
                    result = WlanEnumInterfaces(handle, IntPtr.Zero, ref ppInterfaceList);
                    if (result == 0)
                    {
                        interfaceList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);
                        //记得释放内存
                        WlanFreeMemory(ppInterfaceList);
                        //3.假设只有一个无线设备，通过这个无线设置获取可见网络列表
                        IntPtr ppAvailableNetworkList = new IntPtr();
                        result = WlanGetAvailableNetworkList(handle, ref interfaceList.InterfaceInfo[0].InterfaceGuid, 0x00000002, new IntPtr(), ref  ppAvailableNetworkList);
                        if (result == 0)
                        {
                            WLAN_AVAILABLE_NETWORK_LIST wlan_available_network_list = new WLAN_AVAILABLE_NETWORK_LIST(ppAvailableNetworkList);
                            //这里也不要忘记释放内存
                            WlanFreeMemory(ppAvailableNetworkList);
                            //打印结果出来看看
                            for (int i = 0; i < wlan_available_network_list.wlanAvailableNetwork.Length; i++)
                            {
                                Console.WriteLine(wlan_available_network_list.wlanAvailableNetwork[i].dot11Ssid.ucSSID);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    //记得要关闭句柄
                    WlanCloseHandle(handle, IntPtr.Zero);
                }
            }
        }
    }
}
