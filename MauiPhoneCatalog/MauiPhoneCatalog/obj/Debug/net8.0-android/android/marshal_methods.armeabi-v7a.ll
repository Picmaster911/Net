; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [320 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [634 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 26230656, ; 3: Microsoft.Extensions.DependencyModel => 0x1903f80 => 185
	i32 32687329, ; 4: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 239
	i32 34715100, ; 5: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 273
	i32 34839235, ; 6: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 38948123, ; 7: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 281
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42244203, ; 9: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 290
	i32 42639949, ; 10: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 314
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 196
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 83839681, ; 16: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 298
	i32 101534019, ; 17: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 257
	i32 117431740, ; 18: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 19: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 257
	i32 122350210, ; 20: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 21: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 277
	i32 136584136, ; 22: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 313
	i32 140062828, ; 23: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 306
	i32 142721839, ; 24: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 25: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 26: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 27: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 213
	i32 176265551, ; 28: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 29: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 259
	i32 184328833, ; 30: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 31: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 32: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 211
	i32 220171995, ; 33: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 34: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 233
	i32 230752869, ; 35: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 36: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 37: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 38: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 39: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 216
	i32 276479776, ; 40: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 41: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 235
	i32 280482487, ; 42: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 232
	i32 291076382, ; 43: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 44: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 45: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 311
	i32 318968648, ; 46: Xamarin.AndroidX.Activity.dll => 0x13031348 => 202
	i32 321597661, ; 47: System.Numerics => 0x132b30dd => 83
	i32 321963286, ; 48: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 289
	i32 342366114, ; 49: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 234
	i32 346978296, ; 50: MauiPhoneCatalog => 0x14ae77f8 => 0
	i32 360082299, ; 51: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 52: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 53: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 54: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 55: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 56: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 57: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 58: _Microsoft.Android.Resource.Designer => 0x17969339 => 316
	i32 403441872, ; 59: WindowsBase => 0x180c08d0 => 165
	i32 409257351, ; 60: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 309
	i32 441335492, ; 61: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 217
	i32 442565967, ; 62: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 63: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 230
	i32 451504562, ; 64: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 65: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 66: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 67: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 68: System.dll => 0x1bff388e => 164
	i32 476646585, ; 69: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 232
	i32 486930444, ; 70: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 245
	i32 489220957, ; 71: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 287
	i32 498788369, ; 72: System.ObjectModel => 0x1dbae811 => 84
	i32 513247710, ; 73: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 190
	i32 526420162, ; 74: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 75: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 277
	i32 530272170, ; 76: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 538707440, ; 77: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 308
	i32 539058512, ; 78: Microsoft.Extensions.Logging => 0x20216150 => 186
	i32 540030774, ; 79: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 80: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 81: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 82: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 83: Jsr305Binding => 0x213954e7 => 270
	i32 569601784, ; 84: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 268
	i32 577335427, ; 85: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 601371474, ; 86: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 87: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 88: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 89: Xamarin.AndroidX.CustomView => 0x2568904f => 222
	i32 627931235, ; 90: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 300
	i32 639843206, ; 91: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 228
	i32 643868501, ; 92: System.Net => 0x2660a755 => 81
	i32 662205335, ; 93: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 94: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 264
	i32 666292255, ; 95: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 209
	i32 672442732, ; 96: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 97: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 98: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 99: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 279
	i32 693804605, ; 100: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 101: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 102: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 274
	i32 700358131, ; 103: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 720511267, ; 104: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 278
	i32 722857257, ; 105: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 732010844, ; 106: PhoneCatalog.DAL.dll => 0x2ba1995c => 315
	i32 735137430, ; 107: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 108: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 109: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 199
	i32 759454413, ; 110: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 111: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 112: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 113: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 306
	i32 789151979, ; 114: Microsoft.Extensions.Options => 0x2f0980eb => 189
	i32 790371945, ; 115: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 223
	i32 804715423, ; 116: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 117: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 237
	i32 823281589, ; 118: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 119: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 120: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 121: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 122: Xamarin.AndroidX.Print => 0x3246f6cd => 250
	i32 869139383, ; 123: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 291
	i32 873119928, ; 124: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 125: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 126: System.Net.Http.Json => 0x3463c971 => 63
	i32 880668424, ; 127: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 305
	i32 904024072, ; 128: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 129: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 918734561, ; 130: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 302
	i32 928116545, ; 131: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 273
	i32 930586622, ; 132: PhoneCatalog.DAL => 0x37779ffe => 315
	i32 952186615, ; 133: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 134: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 278
	i32 961460050, ; 135: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 295
	i32 966729478, ; 136: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 271
	i32 967690846, ; 137: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 234
	i32 975236339, ; 138: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 139: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 140: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 141: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 990727110, ; 142: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 304
	i32 992768348, ; 143: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 144: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 145: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 146: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 254
	i32 1019214401, ; 147: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 148: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 184
	i32 1031528504, ; 149: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 272
	i32 1035644815, ; 150: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 207
	i32 1036536393, ; 151: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1043950537, ; 152: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 285
	i32 1044663988, ; 153: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 154: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 241
	i32 1067306892, ; 155: GoogleGson => 0x3f9dcf8c => 173
	i32 1082857460, ; 156: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 157: Xamarin.Kotlin.StdLib => 0x409e66d8 => 275
	i32 1098259244, ; 158: System => 0x41761b2c => 164
	i32 1108272742, ; 159: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 307
	i32 1117529484, ; 160: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 301
	i32 1118262833, ; 161: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 297
	i32 1121599056, ; 162: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 240
	i32 1127624469, ; 163: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 188
	i32 1149092582, ; 164: Xamarin.AndroidX.Window => 0x447dc2e6 => 267
	i32 1157931901, ; 165: Microsoft.EntityFrameworkCore.Abstractions => 0x4504a37d => 176
	i32 1168523401, ; 166: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 303
	i32 1170634674, ; 167: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 168: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 263
	i32 1178241025, ; 169: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 248
	i32 1202000627, ; 170: Microsoft.EntityFrameworkCore.Abstractions.dll => 0x47a512f3 => 176
	i32 1204270330, ; 171: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 209
	i32 1204575371, ; 172: Microsoft.Extensions.Caching.Memory.dll => 0x47cc5c8b => 180
	i32 1208641965, ; 173: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 174: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1243150071, ; 175: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 268
	i32 1253011324, ; 176: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 177: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 283
	i32 1264511973, ; 178: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 258
	i32 1267360935, ; 179: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 262
	i32 1273260888, ; 180: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 214
	i32 1275534314, ; 181: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 279
	i32 1278448581, ; 182: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 206
	i32 1292207520, ; 183: SQLitePCLRaw.core.dll => 0x4d0585a0 => 197
	i32 1293217323, ; 184: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 225
	i32 1308624726, ; 185: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 292
	i32 1309188875, ; 186: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 187: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 267
	i32 1324164729, ; 188: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 189: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1336711579, ; 190: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 312
	i32 1364015309, ; 191: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 192: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 313
	i32 1376866003, ; 193: Xamarin.AndroidX.SavedState => 0x52114ed3 => 254
	i32 1379779777, ; 194: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 195: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 196: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 218
	i32 1408764838, ; 197: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 198: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 199: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 200: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 281
	i32 1434145427, ; 201: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 202: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 271
	i32 1439761251, ; 203: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 204: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 205: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 206: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 207: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 208: es\Microsoft.Maui.Controls.resources => 0x57152abe => 287
	i32 1461234159, ; 209: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 210: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 211: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 212: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 208
	i32 1470490898, ; 213: Microsoft.Extensions.Primitives => 0x57a5e912 => 190
	i32 1479771757, ; 214: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 215: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 216: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 217: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 255
	i32 1490351284, ; 218: Microsoft.Data.Sqlite.dll => 0x58d4f4b4 => 174
	i32 1526286932, ; 219: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 311
	i32 1536373174, ; 220: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 221: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 222: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 223: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 224: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 225: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 226: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 227: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 228: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 224
	i32 1592978981, ; 229: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 230: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 272
	i32 1601112923, ; 231: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 232: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 233: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 234: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 244
	i32 1622358360, ; 235: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 236: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 266
	i32 1635184631, ; 237: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 228
	i32 1636350590, ; 238: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 221
	i32 1639515021, ; 239: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 240: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 241: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 242: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 243: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 260
	i32 1658251792, ; 244: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 269
	i32 1670060433, ; 245: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 216
	i32 1675553242, ; 246: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 247: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 248: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 249: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1688112883, ; 250: Microsoft.Data.Sqlite => 0x649e8ef3 => 174
	i32 1689493916, ; 251: Microsoft.EntityFrameworkCore.dll => 0x64b3a19c => 175
	i32 1691477237, ; 252: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 253: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 254: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 276
	i32 1701541528, ; 255: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 256: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 237
	i32 1726116996, ; 257: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 258: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 259: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 212
	i32 1743415430, ; 260: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 282
	i32 1744735666, ; 261: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 262: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 263: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 264: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 265: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 266: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 267: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 259
	i32 1770582343, ; 268: Microsoft.Extensions.Logging.dll => 0x6988f147 => 186
	i32 1776026572, ; 269: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 270: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 271: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 272: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 298
	i32 1788241197, ; 273: Xamarin.AndroidX.Fragment => 0x6a96652d => 230
	i32 1793755602, ; 274: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 290
	i32 1808609942, ; 275: Xamarin.AndroidX.Loader => 0x6bcd3296 => 244
	i32 1813058853, ; 276: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 275
	i32 1813201214, ; 277: Xamarin.Google.Android.Material => 0x6c13413e => 269
	i32 1818569960, ; 278: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 249
	i32 1818787751, ; 279: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 280: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 281: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 282: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 187
	i32 1847515442, ; 283: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 199
	i32 1853025655, ; 284: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 307
	i32 1858542181, ; 285: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 286: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 287: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 289
	i32 1879696579, ; 288: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 289: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 210
	i32 1886040351, ; 290: Microsoft.EntityFrameworkCore.Sqlite.dll => 0x706ab11f => 178
	i32 1888955245, ; 291: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 292: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1893218855, ; 293: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 283
	i32 1898237753, ; 294: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 295: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 296: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 297: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1953182387, ; 298: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 294
	i32 1956758971, ; 299: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 300: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 256
	i32 1968388702, ; 301: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 181
	i32 1983156543, ; 302: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 276
	i32 1985761444, ; 303: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 201
	i32 2003115576, ; 304: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 286
	i32 2011961780, ; 305: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2014489277, ; 306: Microsoft.EntityFrameworkCore.Sqlite => 0x7812aabd => 178
	i32 2019465201, ; 307: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 241
	i32 2031763787, ; 308: Xamarin.Android.Glide => 0x791a414b => 198
	i32 2045470958, ; 309: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 310: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 236
	i32 2060060697, ; 311: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 312: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 285
	i32 2070888862, ; 313: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 314: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 315: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 316: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 317: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 318: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 319: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 320: Microsoft.Maui => 0x80bd55ad => 194
	i32 2169148018, ; 321: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 293
	i32 2181898931, ; 322: Microsoft.Extensions.Options.dll => 0x820d22b3 => 189
	i32 2192057212, ; 323: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 187
	i32 2193016926, ; 324: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2197979891, ; 325: Microsoft.Extensions.DependencyModel.dll => 0x830282f3 => 185
	i32 2201107256, ; 326: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 280
	i32 2201231467, ; 327: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 328: it\Microsoft.Maui.Controls.resources => 0x839595db => 295
	i32 2217644978, ; 329: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 263
	i32 2222056684, ; 330: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 331: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 245
	i32 2252106437, ; 332: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2252897993, ; 333: Microsoft.EntityFrameworkCore => 0x86487ec9 => 175
	i32 2256313426, ; 334: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 335: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 336: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 182
	i32 2267999099, ; 337: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 200
	i32 2279755925, ; 338: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 252
	i32 2293034957, ; 339: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 340: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 341: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 342: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 299
	i32 2305521784, ; 343: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 344: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 204
	i32 2320631194, ; 345: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 346: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 347: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 348: System.Net.Primitives => 0x8c40e0db => 70
	i32 2366048013, ; 349: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 293
	i32 2368005991, ; 350: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 351: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 181
	i32 2378619854, ; 352: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 353: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 354: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 294
	i32 2401565422, ; 355: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 356: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 227
	i32 2421380589, ; 357: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 358: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 214
	i32 2427813419, ; 359: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 291
	i32 2435356389, ; 360: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 361: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 362: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 363: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 364: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 365: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 217
	i32 2471841756, ; 366: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 367: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 368: Microsoft.Maui.Controls => 0x93dba8a1 => 192
	i32 2483903535, ; 369: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 370: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 371: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 372: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2503351294, ; 373: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 297
	i32 2505896520, ; 374: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 239
	i32 2522472828, ; 375: Xamarin.Android.Glide.dll => 0x9659e17c => 198
	i32 2538310050, ; 376: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 377: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 292
	i32 2562349572, ; 378: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 379: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2576534780, ; 380: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 296
	i32 2581783588, ; 381: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 240
	i32 2581819634, ; 382: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 262
	i32 2585220780, ; 383: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 384: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 385: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 386: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 301
	i32 2605712449, ; 387: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 280
	i32 2615233544, ; 388: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 231
	i32 2616218305, ; 389: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 188
	i32 2617129537, ; 390: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 391: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 392: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 221
	i32 2624644809, ; 393: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 226
	i32 2626831493, ; 394: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 296
	i32 2627185994, ; 395: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 396: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 397: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 235
	i32 2634653062, ; 398: Microsoft.EntityFrameworkCore.Relational.dll => 0x9d099d86 => 177
	i32 2663391936, ; 399: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 200
	i32 2663698177, ; 400: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 401: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 402: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 403: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 404: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 405: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 406: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 260
	i32 2715334215, ; 407: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 408: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 409: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 410: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 411: Xamarin.AndroidX.Activity => 0xa2e0939b => 202
	i32 2735172069, ; 412: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 413: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 208
	i32 2740698338, ; 414: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 282
	i32 2740948882, ; 415: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 416: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 417: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 302
	i32 2758225723, ; 418: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 193
	i32 2764765095, ; 419: Microsoft.Maui.dll => 0xa4caf7a7 => 194
	i32 2765824710, ; 420: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 421: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 274
	i32 2778768386, ; 422: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 265
	i32 2779977773, ; 423: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 253
	i32 2785988530, ; 424: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 308
	i32 2788224221, ; 425: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 231
	i32 2801831435, ; 426: Microsoft.Maui.Graphics => 0xa7008e0b => 196
	i32 2803228030, ; 427: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 428: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 218
	i32 2819470561, ; 429: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 430: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 431: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 253
	i32 2824502124, ; 432: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2838993487, ; 433: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 242
	i32 2847789619, ; 434: Microsoft.EntityFrameworkCore.Relational => 0xa9bdd233 => 177
	i32 2849599387, ; 435: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 436: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 265
	i32 2855708567, ; 437: Xamarin.AndroidX.Transition => 0xaa36a797 => 261
	i32 2861098320, ; 438: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 439: Microsoft.Maui.Essentials => 0xaa8a4878 => 195
	i32 2870099610, ; 440: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 203
	i32 2875164099, ; 441: Jsr305Binding.dll => 0xab5f85c3 => 270
	i32 2875220617, ; 442: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 443: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 229
	i32 2887636118, ; 444: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 445: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 446: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 447: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 448: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 449: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 450: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 266
	i32 2919462931, ; 451: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 452: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 205
	i32 2936416060, ; 453: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 454: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 455: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 456: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 457: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 458: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 459: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 225
	i32 2987532451, ; 460: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 256
	i32 2996846495, ; 461: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 238
	i32 3016983068, ; 462: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 258
	i32 3023353419, ; 463: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 464: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 233
	i32 3038032645, ; 465: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 316
	i32 3053864966, ; 466: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 288
	i32 3056245963, ; 467: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 255
	i32 3057625584, ; 468: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 246
	i32 3059408633, ; 469: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 470: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3069363400, ; 471: Microsoft.Extensions.Caching.Abstractions.dll => 0xb6f2c4c8 => 179
	i32 3075834255, ; 472: System.Threading.Tasks => 0xb755818f => 144
	i32 3090735792, ; 473: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 474: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 475: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 476: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 477: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 478: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 479: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 480: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 481: GoogleGson.dll => 0xbba64c02 => 173
	i32 3159123045, ; 482: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 483: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 484: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 247
	i32 3192346100, ; 485: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 486: System.Web => 0xbe592c0c => 153
	i32 3195844289, ; 487: Microsoft.Extensions.Caching.Abstractions => 0xbe7cb6c1 => 179
	i32 3204380047, ; 488: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 489: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 490: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 224
	i32 3220365878, ; 491: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 492: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 493: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 494: Xamarin.AndroidX.CardView => 0xc235e84d => 212
	i32 3265493905, ; 495: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 496: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 497: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 498: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 499: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 500: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 501: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 502: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 503: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 288
	i32 3316684772, ; 504: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 505: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 222
	i32 3317144872, ; 506: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 507: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 210
	i32 3345895724, ; 508: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 251
	i32 3346324047, ; 509: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 248
	i32 3357674450, ; 510: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 305
	i32 3358260929, ; 511: System.Text.Json => 0xc82afec1 => 137
	i32 3360279109, ; 512: SQLitePCLRaw.core => 0xc849ca45 => 197
	i32 3362336904, ; 513: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 203
	i32 3362522851, ; 514: Xamarin.AndroidX.Core => 0xc86c06e3 => 219
	i32 3366347497, ; 515: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 516: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 252
	i32 3381016424, ; 517: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 284
	i32 3395150330, ; 518: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 519: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 520: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 223
	i32 3428513518, ; 521: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 183
	i32 3429136800, ; 522: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 523: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 524: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 226
	i32 3445260447, ; 525: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 526: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 191
	i32 3458724246, ; 527: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 303
	i32 3471940407, ; 528: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 529: Mono.Android => 0xcf3163e6 => 171
	i32 3484440000, ; 530: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 304
	i32 3485117614, ; 531: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 532: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 533: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 215
	i32 3509114376, ; 534: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 535: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 536: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 537: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 538: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 539: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 540: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 312
	i32 3592228221, ; 541: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 314
	i32 3597029428, ; 542: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 201
	i32 3598340787, ; 543: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 544: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 545: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 546: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 250
	i32 3633644679, ; 547: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 205
	i32 3638274909, ; 548: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 549: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 236
	i32 3643446276, ; 550: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 309
	i32 3643854240, ; 551: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 247
	i32 3645089577, ; 552: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 553: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 182
	i32 3660523487, ; 554: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 555: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 556: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 211
	i32 3684561358, ; 557: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 215
	i32 3700866549, ; 558: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 559: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 220
	i32 3716563718, ; 560: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 561: Xamarin.AndroidX.Annotation => 0xdda814c6 => 204
	i32 3724971120, ; 562: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 246
	i32 3732100267, ; 563: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 564: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 565: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 566: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3751619990, ; 567: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 284
	i32 3786282454, ; 568: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 213
	i32 3792276235, ; 569: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 570: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 191
	i32 3802395368, ; 571: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 572: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 573: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 574: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 575: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 184
	i32 3844307129, ; 576: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 577: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 578: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 579: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 580: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 581: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 582: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 261
	i32 3888767677, ; 583: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 251
	i32 3896106733, ; 584: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 585: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 219
	i32 3901907137, ; 586: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920221145, ; 587: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 300
	i32 3920810846, ; 588: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 589: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 264
	i32 3928044579, ; 590: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 591: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 592: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 249
	i32 3945713374, ; 593: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 594: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 595: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 207
	i32 3959773229, ; 596: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 238
	i32 4003436829, ; 597: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 598: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 206
	i32 4025784931, ; 599: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 600: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 193
	i32 4054681211, ; 601: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 602: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 603: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4091086043, ; 604: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 286
	i32 4094352644, ; 605: Microsoft.Maui.Essentials.dll => 0xf40add04 => 195
	i32 4099507663, ; 606: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 607: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 608: Xamarin.AndroidX.Emoji2 => 0xf479582c => 227
	i32 4101842092, ; 609: Microsoft.Extensions.Caching.Memory => 0xf47d24ac => 180
	i32 4103439459, ; 610: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 310
	i32 4126470640, ; 611: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 183
	i32 4127667938, ; 612: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 613: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 614: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150120506, ; 615: MauiPhoneCatalog.dll => 0xf75dd03a => 0
	i32 4150914736, ; 616: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 310
	i32 4151237749, ; 617: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 618: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 619: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 620: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 621: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 622: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 243
	i32 4185676441, ; 623: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 624: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 625: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4249188766, ; 626: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 299
	i32 4256097574, ; 627: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 220
	i32 4258378803, ; 628: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 242
	i32 4260525087, ; 629: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 630: Microsoft.Maui.Controls.dll => 0xfea12dee => 192
	i32 4274976490, ; 631: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 632: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 243
	i32 4294763496 ; 633: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 229
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [634 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 185, ; 3
	i32 239, ; 4
	i32 273, ; 5
	i32 48, ; 6
	i32 281, ; 7
	i32 80, ; 8
	i32 290, ; 9
	i32 145, ; 10
	i32 30, ; 11
	i32 314, ; 12
	i32 124, ; 13
	i32 196, ; 14
	i32 102, ; 15
	i32 298, ; 16
	i32 257, ; 17
	i32 107, ; 18
	i32 257, ; 19
	i32 139, ; 20
	i32 277, ; 21
	i32 313, ; 22
	i32 306, ; 23
	i32 77, ; 24
	i32 124, ; 25
	i32 13, ; 26
	i32 213, ; 27
	i32 132, ; 28
	i32 259, ; 29
	i32 151, ; 30
	i32 18, ; 31
	i32 211, ; 32
	i32 26, ; 33
	i32 233, ; 34
	i32 1, ; 35
	i32 59, ; 36
	i32 42, ; 37
	i32 91, ; 38
	i32 216, ; 39
	i32 147, ; 40
	i32 235, ; 41
	i32 232, ; 42
	i32 54, ; 43
	i32 69, ; 44
	i32 311, ; 45
	i32 202, ; 46
	i32 83, ; 47
	i32 289, ; 48
	i32 234, ; 49
	i32 0, ; 50
	i32 131, ; 51
	i32 55, ; 52
	i32 149, ; 53
	i32 74, ; 54
	i32 145, ; 55
	i32 62, ; 56
	i32 146, ; 57
	i32 316, ; 58
	i32 165, ; 59
	i32 309, ; 60
	i32 217, ; 61
	i32 12, ; 62
	i32 230, ; 63
	i32 125, ; 64
	i32 152, ; 65
	i32 113, ; 66
	i32 166, ; 67
	i32 164, ; 68
	i32 232, ; 69
	i32 245, ; 70
	i32 287, ; 71
	i32 84, ; 72
	i32 190, ; 73
	i32 150, ; 74
	i32 277, ; 75
	i32 60, ; 76
	i32 308, ; 77
	i32 186, ; 78
	i32 51, ; 79
	i32 103, ; 80
	i32 114, ; 81
	i32 40, ; 82
	i32 270, ; 83
	i32 268, ; 84
	i32 120, ; 85
	i32 52, ; 86
	i32 44, ; 87
	i32 119, ; 88
	i32 222, ; 89
	i32 300, ; 90
	i32 228, ; 91
	i32 81, ; 92
	i32 136, ; 93
	i32 264, ; 94
	i32 209, ; 95
	i32 8, ; 96
	i32 73, ; 97
	i32 155, ; 98
	i32 279, ; 99
	i32 154, ; 100
	i32 92, ; 101
	i32 274, ; 102
	i32 45, ; 103
	i32 278, ; 104
	i32 109, ; 105
	i32 315, ; 106
	i32 129, ; 107
	i32 25, ; 108
	i32 199, ; 109
	i32 72, ; 110
	i32 55, ; 111
	i32 46, ; 112
	i32 306, ; 113
	i32 189, ; 114
	i32 223, ; 115
	i32 22, ; 116
	i32 237, ; 117
	i32 86, ; 118
	i32 43, ; 119
	i32 160, ; 120
	i32 71, ; 121
	i32 250, ; 122
	i32 291, ; 123
	i32 3, ; 124
	i32 42, ; 125
	i32 63, ; 126
	i32 305, ; 127
	i32 16, ; 128
	i32 53, ; 129
	i32 302, ; 130
	i32 273, ; 131
	i32 315, ; 132
	i32 105, ; 133
	i32 278, ; 134
	i32 295, ; 135
	i32 271, ; 136
	i32 234, ; 137
	i32 34, ; 138
	i32 158, ; 139
	i32 85, ; 140
	i32 32, ; 141
	i32 304, ; 142
	i32 12, ; 143
	i32 51, ; 144
	i32 56, ; 145
	i32 254, ; 146
	i32 36, ; 147
	i32 184, ; 148
	i32 272, ; 149
	i32 207, ; 150
	i32 35, ; 151
	i32 285, ; 152
	i32 58, ; 153
	i32 241, ; 154
	i32 173, ; 155
	i32 17, ; 156
	i32 275, ; 157
	i32 164, ; 158
	i32 307, ; 159
	i32 301, ; 160
	i32 297, ; 161
	i32 240, ; 162
	i32 188, ; 163
	i32 267, ; 164
	i32 176, ; 165
	i32 303, ; 166
	i32 153, ; 167
	i32 263, ; 168
	i32 248, ; 169
	i32 176, ; 170
	i32 209, ; 171
	i32 180, ; 172
	i32 29, ; 173
	i32 52, ; 174
	i32 268, ; 175
	i32 5, ; 176
	i32 283, ; 177
	i32 258, ; 178
	i32 262, ; 179
	i32 214, ; 180
	i32 279, ; 181
	i32 206, ; 182
	i32 197, ; 183
	i32 225, ; 184
	i32 292, ; 185
	i32 85, ; 186
	i32 267, ; 187
	i32 61, ; 188
	i32 112, ; 189
	i32 312, ; 190
	i32 57, ; 191
	i32 313, ; 192
	i32 254, ; 193
	i32 99, ; 194
	i32 19, ; 195
	i32 218, ; 196
	i32 111, ; 197
	i32 101, ; 198
	i32 102, ; 199
	i32 281, ; 200
	i32 104, ; 201
	i32 271, ; 202
	i32 71, ; 203
	i32 38, ; 204
	i32 32, ; 205
	i32 103, ; 206
	i32 73, ; 207
	i32 287, ; 208
	i32 9, ; 209
	i32 123, ; 210
	i32 46, ; 211
	i32 208, ; 212
	i32 190, ; 213
	i32 9, ; 214
	i32 43, ; 215
	i32 4, ; 216
	i32 255, ; 217
	i32 174, ; 218
	i32 311, ; 219
	i32 31, ; 220
	i32 138, ; 221
	i32 92, ; 222
	i32 93, ; 223
	i32 49, ; 224
	i32 141, ; 225
	i32 112, ; 226
	i32 140, ; 227
	i32 224, ; 228
	i32 115, ; 229
	i32 272, ; 230
	i32 157, ; 231
	i32 76, ; 232
	i32 79, ; 233
	i32 244, ; 234
	i32 37, ; 235
	i32 266, ; 236
	i32 228, ; 237
	i32 221, ; 238
	i32 64, ; 239
	i32 138, ; 240
	i32 15, ; 241
	i32 116, ; 242
	i32 260, ; 243
	i32 269, ; 244
	i32 216, ; 245
	i32 48, ; 246
	i32 70, ; 247
	i32 80, ; 248
	i32 126, ; 249
	i32 174, ; 250
	i32 175, ; 251
	i32 94, ; 252
	i32 121, ; 253
	i32 276, ; 254
	i32 26, ; 255
	i32 237, ; 256
	i32 97, ; 257
	i32 28, ; 258
	i32 212, ; 259
	i32 282, ; 260
	i32 149, ; 261
	i32 169, ; 262
	i32 4, ; 263
	i32 98, ; 264
	i32 33, ; 265
	i32 93, ; 266
	i32 259, ; 267
	i32 186, ; 268
	i32 21, ; 269
	i32 41, ; 270
	i32 170, ; 271
	i32 298, ; 272
	i32 230, ; 273
	i32 290, ; 274
	i32 244, ; 275
	i32 275, ; 276
	i32 269, ; 277
	i32 249, ; 278
	i32 2, ; 279
	i32 134, ; 280
	i32 111, ; 281
	i32 187, ; 282
	i32 199, ; 283
	i32 307, ; 284
	i32 58, ; 285
	i32 95, ; 286
	i32 289, ; 287
	i32 39, ; 288
	i32 210, ; 289
	i32 178, ; 290
	i32 25, ; 291
	i32 94, ; 292
	i32 283, ; 293
	i32 89, ; 294
	i32 99, ; 295
	i32 10, ; 296
	i32 87, ; 297
	i32 294, ; 298
	i32 100, ; 299
	i32 256, ; 300
	i32 181, ; 301
	i32 276, ; 302
	i32 201, ; 303
	i32 286, ; 304
	i32 7, ; 305
	i32 178, ; 306
	i32 241, ; 307
	i32 198, ; 308
	i32 88, ; 309
	i32 236, ; 310
	i32 154, ; 311
	i32 285, ; 312
	i32 33, ; 313
	i32 116, ; 314
	i32 82, ; 315
	i32 20, ; 316
	i32 11, ; 317
	i32 162, ; 318
	i32 3, ; 319
	i32 194, ; 320
	i32 293, ; 321
	i32 189, ; 322
	i32 187, ; 323
	i32 84, ; 324
	i32 185, ; 325
	i32 280, ; 326
	i32 64, ; 327
	i32 295, ; 328
	i32 263, ; 329
	i32 143, ; 330
	i32 245, ; 331
	i32 157, ; 332
	i32 175, ; 333
	i32 41, ; 334
	i32 117, ; 335
	i32 182, ; 336
	i32 200, ; 337
	i32 252, ; 338
	i32 131, ; 339
	i32 75, ; 340
	i32 66, ; 341
	i32 299, ; 342
	i32 172, ; 343
	i32 204, ; 344
	i32 143, ; 345
	i32 106, ; 346
	i32 151, ; 347
	i32 70, ; 348
	i32 293, ; 349
	i32 156, ; 350
	i32 181, ; 351
	i32 121, ; 352
	i32 127, ; 353
	i32 294, ; 354
	i32 152, ; 355
	i32 227, ; 356
	i32 141, ; 357
	i32 214, ; 358
	i32 291, ; 359
	i32 20, ; 360
	i32 14, ; 361
	i32 135, ; 362
	i32 75, ; 363
	i32 59, ; 364
	i32 217, ; 365
	i32 167, ; 366
	i32 168, ; 367
	i32 192, ; 368
	i32 15, ; 369
	i32 74, ; 370
	i32 6, ; 371
	i32 23, ; 372
	i32 297, ; 373
	i32 239, ; 374
	i32 198, ; 375
	i32 91, ; 376
	i32 292, ; 377
	i32 1, ; 378
	i32 136, ; 379
	i32 296, ; 380
	i32 240, ; 381
	i32 262, ; 382
	i32 134, ; 383
	i32 69, ; 384
	i32 146, ; 385
	i32 301, ; 386
	i32 280, ; 387
	i32 231, ; 388
	i32 188, ; 389
	i32 88, ; 390
	i32 96, ; 391
	i32 221, ; 392
	i32 226, ; 393
	i32 296, ; 394
	i32 31, ; 395
	i32 45, ; 396
	i32 235, ; 397
	i32 177, ; 398
	i32 200, ; 399
	i32 109, ; 400
	i32 158, ; 401
	i32 35, ; 402
	i32 22, ; 403
	i32 114, ; 404
	i32 57, ; 405
	i32 260, ; 406
	i32 144, ; 407
	i32 118, ; 408
	i32 120, ; 409
	i32 110, ; 410
	i32 202, ; 411
	i32 139, ; 412
	i32 208, ; 413
	i32 282, ; 414
	i32 54, ; 415
	i32 105, ; 416
	i32 302, ; 417
	i32 193, ; 418
	i32 194, ; 419
	i32 133, ; 420
	i32 274, ; 421
	i32 265, ; 422
	i32 253, ; 423
	i32 308, ; 424
	i32 231, ; 425
	i32 196, ; 426
	i32 159, ; 427
	i32 218, ; 428
	i32 163, ; 429
	i32 132, ; 430
	i32 253, ; 431
	i32 161, ; 432
	i32 242, ; 433
	i32 177, ; 434
	i32 140, ; 435
	i32 265, ; 436
	i32 261, ; 437
	i32 169, ; 438
	i32 195, ; 439
	i32 203, ; 440
	i32 270, ; 441
	i32 40, ; 442
	i32 229, ; 443
	i32 81, ; 444
	i32 56, ; 445
	i32 37, ; 446
	i32 97, ; 447
	i32 166, ; 448
	i32 172, ; 449
	i32 266, ; 450
	i32 82, ; 451
	i32 205, ; 452
	i32 98, ; 453
	i32 30, ; 454
	i32 159, ; 455
	i32 18, ; 456
	i32 127, ; 457
	i32 119, ; 458
	i32 225, ; 459
	i32 256, ; 460
	i32 238, ; 461
	i32 258, ; 462
	i32 165, ; 463
	i32 233, ; 464
	i32 316, ; 465
	i32 288, ; 466
	i32 255, ; 467
	i32 246, ; 468
	i32 170, ; 469
	i32 16, ; 470
	i32 179, ; 471
	i32 144, ; 472
	i32 125, ; 473
	i32 118, ; 474
	i32 38, ; 475
	i32 115, ; 476
	i32 47, ; 477
	i32 142, ; 478
	i32 117, ; 479
	i32 34, ; 480
	i32 173, ; 481
	i32 95, ; 482
	i32 53, ; 483
	i32 247, ; 484
	i32 129, ; 485
	i32 153, ; 486
	i32 179, ; 487
	i32 24, ; 488
	i32 161, ; 489
	i32 224, ; 490
	i32 148, ; 491
	i32 104, ; 492
	i32 89, ; 493
	i32 212, ; 494
	i32 60, ; 495
	i32 142, ; 496
	i32 100, ; 497
	i32 5, ; 498
	i32 13, ; 499
	i32 122, ; 500
	i32 135, ; 501
	i32 28, ; 502
	i32 288, ; 503
	i32 72, ; 504
	i32 222, ; 505
	i32 24, ; 506
	i32 210, ; 507
	i32 251, ; 508
	i32 248, ; 509
	i32 305, ; 510
	i32 137, ; 511
	i32 197, ; 512
	i32 203, ; 513
	i32 219, ; 514
	i32 168, ; 515
	i32 252, ; 516
	i32 284, ; 517
	i32 101, ; 518
	i32 123, ; 519
	i32 223, ; 520
	i32 183, ; 521
	i32 163, ; 522
	i32 167, ; 523
	i32 226, ; 524
	i32 39, ; 525
	i32 191, ; 526
	i32 303, ; 527
	i32 17, ; 528
	i32 171, ; 529
	i32 304, ; 530
	i32 137, ; 531
	i32 150, ; 532
	i32 215, ; 533
	i32 155, ; 534
	i32 130, ; 535
	i32 19, ; 536
	i32 65, ; 537
	i32 147, ; 538
	i32 47, ; 539
	i32 312, ; 540
	i32 314, ; 541
	i32 201, ; 542
	i32 79, ; 543
	i32 61, ; 544
	i32 106, ; 545
	i32 250, ; 546
	i32 205, ; 547
	i32 49, ; 548
	i32 236, ; 549
	i32 309, ; 550
	i32 247, ; 551
	i32 14, ; 552
	i32 182, ; 553
	i32 68, ; 554
	i32 171, ; 555
	i32 211, ; 556
	i32 215, ; 557
	i32 78, ; 558
	i32 220, ; 559
	i32 108, ; 560
	i32 204, ; 561
	i32 246, ; 562
	i32 67, ; 563
	i32 63, ; 564
	i32 27, ; 565
	i32 160, ; 566
	i32 284, ; 567
	i32 213, ; 568
	i32 10, ; 569
	i32 191, ; 570
	i32 11, ; 571
	i32 78, ; 572
	i32 126, ; 573
	i32 83, ; 574
	i32 184, ; 575
	i32 66, ; 576
	i32 107, ; 577
	i32 65, ; 578
	i32 128, ; 579
	i32 122, ; 580
	i32 77, ; 581
	i32 261, ; 582
	i32 251, ; 583
	i32 8, ; 584
	i32 219, ; 585
	i32 2, ; 586
	i32 300, ; 587
	i32 44, ; 588
	i32 264, ; 589
	i32 156, ; 590
	i32 128, ; 591
	i32 249, ; 592
	i32 23, ; 593
	i32 133, ; 594
	i32 207, ; 595
	i32 238, ; 596
	i32 29, ; 597
	i32 206, ; 598
	i32 62, ; 599
	i32 193, ; 600
	i32 90, ; 601
	i32 87, ; 602
	i32 148, ; 603
	i32 286, ; 604
	i32 195, ; 605
	i32 36, ; 606
	i32 86, ; 607
	i32 227, ; 608
	i32 180, ; 609
	i32 310, ; 610
	i32 183, ; 611
	i32 50, ; 612
	i32 6, ; 613
	i32 90, ; 614
	i32 0, ; 615
	i32 310, ; 616
	i32 21, ; 617
	i32 162, ; 618
	i32 96, ; 619
	i32 50, ; 620
	i32 113, ; 621
	i32 243, ; 622
	i32 130, ; 623
	i32 76, ; 624
	i32 27, ; 625
	i32 299, ; 626
	i32 220, ; 627
	i32 242, ; 628
	i32 7, ; 629
	i32 192, ; 630
	i32 110, ; 631
	i32 243, ; 632
	i32 229 ; 633
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
