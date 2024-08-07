USE [master]
GO
/****** Object:  Database [PhoneS]    Script Date: 7/15/2024 12:27:39 PM ******/
CREATE DATABASE [PhoneS]

 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PhoneS] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [PhoneS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhoneS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhoneS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhoneS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhoneS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhoneS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhoneS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhoneS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhoneS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhoneS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhoneS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhoneS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhoneS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhoneS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhoneS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhoneS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhoneS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhoneS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhoneS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhoneS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhoneS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhoneS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhoneS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PhoneS] SET  MULTI_USER 
GO
ALTER DATABASE [PhoneS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhoneS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhoneS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhoneS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PhoneS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PhoneS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PhoneS] SET QUERY_STORE = ON
GO
ALTER DATABASE [PhoneS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PhoneS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[MoneySum] [real] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[VoucherID] [int] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Account] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Nationality] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Salary] [real] NOT NULL,
	[CoefSalary] [real] NOT NULL,
	[Account] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Price] [real] NOT NULL,
	[Picture] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ProdCateID] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductBill]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductBill](
	[ProductID] [int] NOT NULL,
	[BillID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductBill] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProdCateID] [int] IDENTITY(1,1) NOT NULL,
	[ProdCateName] [nvarchar](max) NOT NULL,
	[linkImage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProdCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ImageLink] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ProductID] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductInfo]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInfo](
	[ProductID] [int] NOT NULL,
	[Screen] [nvarchar](max) NOT NULL,
	[OS] [nvarchar](max) NOT NULL,
	[FrontCam] [nvarchar](max) NOT NULL,
	[BackCam] [nvarchar](max) NOT NULL,
	[Chip] [nvarchar](max) NOT NULL,
	[Ram] [nvarchar](max) NOT NULL,
	[Storage] [nvarchar](max) NOT NULL,
	[SIM] [nvarchar](max) NOT NULL,
	[Battery] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductInfo] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSale]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSale](
	[ProdSaleID] [int] IDENTITY(1,1) NOT NULL,
	[DateStarted] [datetime2](7) NOT NULL,
	[DateEnded] [datetime2](7) NOT NULL,
	[PercentSale] [real] NOT NULL,
	[PriceSale] [real] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProductSale] PRIMARY KEY CLUSTERED 
(
	[ProdSaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
	[RoleDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ForgotPassowrd] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/15/2024 12:27:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[VoucherID] [int] IDENTITY(1,1) NOT NULL,
	[DateStarted] [datetime2](7) NOT NULL,
	[DateEnded] [datetime2](7) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[PriceSale] [real] NOT NULL,
	[UseTimess] [int] NOT NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240712092349_init', N'6.0.15')
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillID], [DateCreated], [MoneySum], [EmployeeID], [CustomerID], [VoucherID]) VALUES (1, CAST(N'2024-07-14T12:43:04.4383720' AS DateTime2), 1199000, -1, 1, -1)
INSERT [dbo].[Bill] ([BillID], [DateCreated], [MoneySum], [EmployeeID], [CustomerID], [VoucherID]) VALUES (2, CAST(N'2024-07-15T11:46:42.1157526' AS DateTime2), 1.199E+07, -1, 1, -1)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [FullName], [Nationality], [Phone], [Address], [Email], [Account]) VALUES (1, N'Nguyễn Hửu Trọng', N'Việt Nam', N'0522383658', N'Long An', N'trongnguyen.02.stu@gmail.com', N'2')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [FullName], [Nationality], [Phone], [Email], [Salary], [CoefSalary], [Account]) VALUES (2, N'Nguyễn Hửu Trọng', N'Mỹ', N'0522383658', N'employee@gmail.com', 1E+07, 1, N'1')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (1, N'Iphone ProTest', 1199000, N'sp1.jpg', 50, N'Apple đã chính thức trình làng bộ 3 siêu phẩm iPhone 11, trong đó phiên bản iPhone 11 64GB có mức giá rẻ nhất nhưng vẫn được nâng cấp mạnh mẽ như iPhone Xr ra mắt trước đó.', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (2, N'Iphone Test
', 1.649E+07, N'sp2.jpg', 50, N'Trong những tháng cuối năm 2020, Apple đã chính thức giới thiệu đến người dùng cũng như iFan thế hệ iPhone 12 series mới với hàng loạt tính năng bứt phá, thiết kế được lột xác hoàn toàn, hiệu năng đầy mạnh mẽ và một trong số đó chính là iPhone 12 64GB.
', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (3, N'Iphone 11', 1.199E+07, N'sp3.jpg', 50, N'Apple đã chính thức trình làng bộ 3 siêu phẩm iPhone 11, trong đó phiên bản iPhone 11 64GB có mức giá rẻ nhất nhưng vẫn được nâng cấp mạnh mẽ như iPhone Xr ra mắt trước đó.', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (4, N'Iphone 12
', 1.649E+07, N'sp4.jpg', 50, N'Trong những tháng cuối năm 2020, Apple đã chính thức giới thiệu đến người dùng cũng như iFan thế hệ iPhone 12 series mới với hàng loạt tính năng bứt phá, thiết kế được lột xác hoàn toàn, hiệu năng đầy mạnh mẽ và một trong số đó chính là iPhone 12 64GB.
', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (5, N'Iphone 13', 1.999E+07, N'sp5.jpg', 50, N'Trong khi sức hút đến từ bộ 4 phiên bản iPhone 12 vẫn chưa nguội đi, thì hãng điện thoại Apple đã mang đến cho người dùng một siêu phẩm mới iPhone 13 với nhiều cải tiến thú vị sẽ mang lại những trải nghiệm hấp dẫn nhất cho người dùng.
', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (6, N'Iphone 14 Plus', 2.449E+07, N'sp6.jpg', 50, N'Sau nhiều thế hệ điện thoại của Apple thì cái tên “Plus” cũng đã chính thức trở lại vào năm 2022 và xuất hiện trên chiếc iPhone 14 Plus 128GB, nổi trội với ngoại hình bắt trend cùng màn hình kích thước lớn để đem đến không gian hiển thị tốt hơn cùng cấu hình mạnh mẽ không đổi so với bản tiêu chuẩn.
', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (7, N'Samsung Galaxy S23 5G', 2.199E+07, N'sp7.jpg', 50, N'Samsung Galaxy S23 có thể xem là cái tên mở màn cho dòng điện thoại cao cấp được nhà Samsung giới thiệu vào dịp đầu năm 2023, kể từ lúc chính thức ra mắt máy nhận được khá nhiều sự quan tâm với hàng loạt thông tin cấu hình hết sức nổi bật như con chip hàng đầu Qualcomm cùng bộ camera siêu chất lượng.', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (8, N'Samsung Galaxy S21 FE 5G', 1.099E+07, N'sp8.jpg', 50, N'Samsung Galaxy S21 FE 5G (6GB/128GB) được Samsung ra mắt với dáng dấp thời thượng, cấu hình khỏe, chụp ảnh đẹp với bộ 3 camera chất lượng, thời lượng pin đủ dùng hằng ngày và còn gì nữa? Mời bạn khám phá qua nội dung sau ngay.', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (9, N'Samsung Galaxy S23 Ultra 5G', 2.699E+07, N'sp9.jpg', 50, N'Cuối cùng thì chiếc điện thoại Samsung Galaxy S23 cũng đã chính thức ra mắt tại sự kiện Galaxy Unpacked vào đầu tháng 2 năm 2023, máy nổi bật với camera 200 MP chất lượng, hiệu năng mạnh mẽ nhờ tích hợp con chip Snapdragon 8 Gen 2 và được trang bị thêm nhiều công nghệ hàng đầu trong giới smartphone.', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (10, N'Samsung Galaxy A23
', 4990000, N'sp10.jpg', 50, N'Samsung Galaxy A23 4GB sở hữu bộ thông số kỹ thuật khá ấn tượng trong phân khúc, máy có một hiệu năng ổn định, cụm 4 camera thông minh cùng một diện mạo trẻ trung phù hợp cho mọi đối tượng người dùng.', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (11, N'Samsung Galaxy S20 FE (8GB/256GB)
', 9490000, N'sp11.jpg', 50, N'Samsung đã giới thiệu đến người dùng thành viên mới của dòng S20 Series đó chính là điện thoại Samsung Galaxy S20 FE. Đây là mẫu flagship cao cấp quy tụ nhiều tính năng mà Samfan yêu thích, hứa hẹn sẽ mang lại trải nghiệm cao cấp của dòng Galaxy S với mức giá dễ tiếp cận hơn.', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (12, N'Samsung Galaxy S23+ 5G
', 2.499E+07, N'sp12.jpg', 50, N'Samsung Galaxy S23 Plus chính thức ra mắt ở sự kiện Galaxy Unpacked vào đầu tháng 2 năm 2023, điện thoại nhận được rất nhiều sự quan tâm của cộng đồng yêu công nghệ trên thế giới, máy sẽ được vận hành trên chipset Qualcomm 8 Gen 2 mới nhất, màn hình Dynamic AMOLED 2X sắc nét và cụm camera xịn sò.
', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (13, N'Samsung Galaxy Z Fold4 5G
', 3.799E+07, N'sp13.jpg', 50, N'Tại sự kiện Samsung Unpacked thường niên, Samsung Galaxy Z Fold4 256GB chính thức được trình làng thị trường công nghệ, mang trên mình nhiều cải tiến đáng giá giúp Galaxy Z Fold trở thành dòng điện thoại gập đã tốt nay càng tốt hơn.
', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (14, N'Samsung Galaxy A04s
', 3590000, N'sp14.jpg', 50, N'Samsung Galaxy A04s mang nhiều cải tiến so với thế hệ Galaxy A03s, màn hình hỗ trợ tần số quét 90 Hz cho trải nghiệm mượt mà cùng camera độ phân giải lên đến 50 MP để bạn nhiếp ảnh thêm tự tin, hứa hẹn mang đầy đủ các tính năng cần thiết ở một chiếc điện thoại dòng A giá rẻ.
', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (15, N'Samsung Galaxy Z Fold3 5G 512GB
', 2.799E+07, N'sp15.jpg', 50, N'Samsung Galaxy Z Fold3 5G 512GB đánh dấu bước tiến mới của hãng trong phân khúc điện thoại gập cao cấp khi được cải tiến về độ bền cùng những nâng cấp đáng giá về cấu hình hiệu năng, hứa hẹn sẽ mang đến trải nghiệm sử dụng đột phá cho người dùng.
', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (16, N'Samsung Galaxy S22 Ultra 5G
', 2.299E+07, N'sp16.jpg', 50, N'Galaxy S22 Ultra 5G chiếc smartphone cao cấp nhất trong bộ 3 Galaxy S22 series mà Samsung đã cho ra mắt. Tích hợp bút S Pen hoàn hảo trong thân máy, trang bị vi xử lý mạnh mẽ cho các tác vụ sử dụng vô cùng mượt mà và nổi bật hơn với cụm camera không viền độc đáo mang đậm dấu ấn riêng.
', 2)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (17, N'Xiaomi Redmi 12C
', 3190000, N'sp17.jpg', 50, N'Xiaomi Redmi 12C 64GB là một thiết bị di động tầm trung được giới thiệu bởi Xiaomi, với cấu hình vượt trội so với các đối thủ trong cùng phân khúc, điều này nhờ trang bị con chip MediaTek Helio G85 mạnh mẽ giúp máy có thể xử lý tốt nhiều tác vụ. Hơn nữa, với bộ ống kính chất lượng 50 MP cho phép bạn chụp ảnh chất lượng, sắc nét và đẹp mắt.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (18, N'Xiaomi Redmi Note 11
', 3990000, N'sp18.jpg', 50, N'Xiaomi Redmi Note 11 (4GB/128GB) chính thức cập bến phân khúc smartphone giá tầm trung, cấu hình khá ổn từ chip Snapdragon và một ngoại hình trẻ trung, sang đẹp cùng cụm camera chất lượng, sẽ là lựa chọn tốt vừa túi tiền cho mọi khách hàng.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (19, N'POCO C40
', 2690000, N'sp19.jpg', 50, N'Tháng 06/2022 điện thoại POCO C40 đã chính thức được cho ra mắt tại thị trường Việt Nam, sở hữu màn hình kích thước lớn, viên pin dung lượng khủng và một con chip JR510 mới lạ trên thị trường công nghệ hiện nay.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (20, N'Xiaomi 12T
', 1.149E+07, N'sp20.jpg', 50, N'Xiaomi 12T series đã ra mắt trong sự kiện của Xiaomi vào ngày 4/10, trong đó có Xiaomi 12T 5G 128GB - máy sở hữu nhiều công nghệ hàng đầu trong giới smartphone tiêu biểu như: Chipset mạnh mẽ đến từ MediaTek, camera 108 MP sắc nét cùng khả năng sạc 120 W siêu nhanh.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (21, N'Xiaomi 13 series
', 1.899E+07, N'sp21.jpg', 50, N'Thông tin ra mắt về Xiaomi 13 hiện đang là chủ đề cực kỳ hot trên các diễn đàn bởi lần ra mắt này Xiaomi mang đến cho chúng ta khá nhiều điều mới mẻ, từ con chip Snapdragon 8 Gen 2 cho đến camera hợp tác với hãng Leica cũng đủ để thu hút các Mi fan hay tín đồ đam mê công nghệ.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (22, N'Xiaomi 11 Lite 5G NE
', 7090000, N'sp22.jpg', 50, N'Xiaomi 11 Lite 5G NE một phiên bản có ngoại hình rất giống với Xiaomi Mi 11 Lite được ra mắt trước đây. Chiếc smartphone này của Xiaomi mang trong mình một hiệu năng ổn định, thiết kế sang trọng và màn hình lớn đáp ứng tốt các tác vụ hằng ngày của bạn một cách dễ dàng.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (23, N'Xiaomi Redmi Note 11 Pro Series
', 5990000, N'sp23.jpg', 50, N'Xiaomi Redmi Note 11 Pro 4G mang trong mình khá nhiều những nâng cấp cực kì sáng giá. Là chiếc điện thoại có màn hình lớn, tần số quét 120 Hz, hiệu năng ổn định cùng một viên pin siêu trâu.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (24, N'Xiaomi Redmi Note 11S
', 5690000, N'sp24.jpg', 50, N'Điện thoại Xiaomi Redmi Note 11S sẵn sàng đem đến cho bạn những trải nghiệm vô cùng hoàn hảo về chơi game, các tác vụ sử dụng hằng ngày hay sự ấn tượng từ vẻ đẹp bên ngoài.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (25, N'Xiaomi Redmi 10 (2022)

', 3590000, N'sp25.jpg', 50, N'Xiaomi Redmi 10 (2022) được ra mắt vào tháng 05/2022 với những nâng cấp về thuật toán xử lý khi chụp ảnh trên camera nhằm giúp khách hàng có được những bức hình chất lượng hơn trên một thiết bị thuộc phân khúc giá rẻ.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (26, N'Xiaomi Redmi 10C
', 2090000, N'sp26.jpg', 50, N'Xiaomi Redmi 10C 64GB ra mắt với một cấu hình mạnh mẽ nhờ trang bị con chip 6 nm đến từ Qualcomm, màn hình hiển thị đẹp mắt, pin đáp ứng nhu cầu sử dụng cả ngày, hứa hẹn mang đến trải nghiệm tuyệt vời so với mức giá mà nó trang bị.
', 3)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (27, N'OPPO Reno8 T 5G', 1.099E+07, N'sp27.jpg', 50, N'Tiếp nối sự thành công rực rỡ đến từ các thế hệ trước đó thì chiếc OPPO Reno8 T 5G 256GB cuối cùng đã được giới thiệu chính thức tại Việt Nam, được định hình là dòng sản phẩm thuộc phân khúc tầm trung với camera 108 MP, con chip Snapdragon 695 cùng kiểu dáng thiết kế mặt lưng và màn hình bo cong hết sức nổi bật.
', 4)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (28, N'OPPO Reno8 series
', 1.799E+07, N'sp28.jpg', 50, N'OPPO Reno8 Pro 5G là chiếc điện thoại cao cấp được nhà OPPO ra mắt vào thời điểm 09/2022, máy hướng đến sự hoàn thiện cao cấp ở phần thiết kế cùng khả năng quay chụp chuyên nghiệp nhờ trang bị vi xử lý hình ảnh MariSilicon X chuyên dụng.
', 4)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (29, N'OPPO A55
', 3690000, N'sp29.jpg', 50, N'OPPO cho ra mắt OPPO A55 4G chiếc smartphone giá rẻ tầm trung có thiết kế đẹp mắt, cấu hình khá ổn, cụm camera chất lượng và dung lượng pin ấn tượng, mang đến một lựa chọn trải nghiệm thú vị vừa túi tiền cho người tiêu dùng.
', 4)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (30, N'OPPO A16K
', 2590000, N'sp30.jpg', 50, N'OPPO chính thức trình làng mẫu smartphone giá rẻ - OPPO A16K sở hữu màu sắc thời thượng, viên pin dung lượng cao, cấu hình khỏe, selfie lung linh, một lựa chọn thú vị cho người tiêu dùng.
', 4)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (31, N'OPPO Find X5 Pro 5G
', 2.499E+07, N'sp31.jpg', 50, N'OPPO Find X5 Pro 5G có lẽ là cái tên sáng giá được xướng tên trong danh sách điện thoại có thiết kế ấn tượng trong năm 2022. Máy được hãng cho ra mắt với một diện mạo độc lạ chưa từng có, cùng với đó là những nâng cấp về chất lượng ở camera nhờ sự hợp tác với nhà sản xuất máy ảnh Hasselblad. 
', 4)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (32, N'Realme C30s
', 2250000, N'sp32.jpg', 50, N'Mới đây thì chiếc điện thoại Realme C30s (2GB/32GB) cũng đã chính thức lộ diện đúng như dự kiến của người dùng với bộ thông số kỹ thuật khá ấn tượng cùng mức giá hợp lý. Điều này giúp nâng cao trải nghiệm một cách tốt hơn đối với những dòng sản phẩm thuộc phân khúc giá rẻ.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (33, N'Realme 10', 7190000, N'sp33.jpg', 50, N'Realme 10 có thể xem là một trong những mẫu smartphone đáng mong đợi nhất trong dịp đầu năm 2023 với nhiều điểm nổi bật, một số điểm đáng chú ý có thể kể đến như: Tấm nền Super AMOLED, camera siêu độ phân giải 50 MP đi kèm con chip Helio G99 mạnh mẽ.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (34, N'Realme 9 series', 7490000, N'sp34.jpg', 50, N'Realme 9 Pro+ 5G - chiếc smartphone tầm trung của Realme đã được ra mắt, máy có một thiết kế đầy màu sắc, cụm 3 camera với cảm biến IMX766 giúp bạn có được những bức ảnh sinh động.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (35, N'Realme 8 series
', 5790000, N'sp35.jpg', 50, N'Bên cạnh Realme 8, Realme 8 Pro cũng được giới thiệu đến người dùng với điểm nhấn chính là sự xuất hiện của camera 108 MP siêu nét cùng công nghệ sạc SuperDart 50 W và đi kèm mức giá bán tầm trung rất lý tưởng.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (36, N'Realme 9
', 5190000, N'sp36.jpg', 50, N'Realme 9 4G hiện đang là một cái tên được cộng đồng người dùng smartphone hết sức quan tâm và đón nhận, nhờ sở hữu trong mình công nghệ màn hình xịn sò, khả năng chụp ảnh siêu độ phân giải với camera chính 108 MP.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (37, N'Realme C55
', 4990000, N'sp37.jpg', 50, N'Gần đây, chiếc điện thoại Realme C55 đã được giới thiệu chính thức với bộ thông số kỹ thuật đáng chú ý và giá cả phù hợp cho người dùng, hãng tạo ra sản phẩm này nhằm cải thiện trải nghiệm cho những sản phẩm thuộc phân khúc giá rẻ.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (38, N'Realme C25Y
', 3940000, N'sp38.jpg', 50, N'Realme C25Y 64GB - là chiếc smartphone được Realme cho ra mắt với một mức giá khá tốt, sở hữu thiết kế hiện đại với 3 camera AI lên đến 50 MP, hiệu suất ổn định cùng thời gian sử dụng lâu dài nhờ viên pin khủng 5000 mAh, được xem là một trong những sản phẩm lý tưởng mà bạn nên sở hữu.
', 5)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (39, N'Nokia C21 Plus
', 2390000, N'sp39.jpg', 50, N'Tiếp nối sự thành công của những sản phẩm gần đây tại thị trường Việt Nam, lần này hãng Nokia đã mang đến mẫu điện thoại Nokia C21 Plus - sở hữu trong mình viên pin mang lại thời gian trải nghiệm lâu dài và sử dụng an tâm hơn với 2 năm cập nhật bảo mật.
', 6)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (40, N'Nokia C31 (3GB/32GB)
', 2490000, N'sp40.jpg', 50, N'Nokia C31 (3GB/32GB) là chiếc điện thoại được nhà HMD Global ra mắt và kinh doanh chính thức tại thị trường Việt Nam vào tháng 10/2022, máy được chú trọng khá nhiều về phần dung lượng pin và màn hình, điều này nhằm mang đến cho người dùng những trải nghiệm xem phim, lướt web tốt hơn.
', 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (41, N'Nokia G11 Plus 64GB
', 2290000, N'sp41.jpg', 50, N'Nokia G11 Plus 64GB có lẽ là một sự lựa chọn lý tưởng dành cho những ai đang mong muốn tìm mua cho mình một chiếc smartphone giá rẻ đáp ứng tốt các nhu cầu nghe gọi hay xem phim. Máy được trang bị bên trong một cấu hình ổn định, màn hình chất lượng có kích thước lớn giúp nâng cao trải nghiệm hàng ngày của bạn.
', 6)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (42, N'Nokia C30
', 1950000, N'sp42.jpg', 50, N'Điện thoại Nokia C30 là dòng smartphone giá rẻ được hãng Nokia chăm chút và đầu tư kỹ lưỡng với những nâng cấp đáng kể về hiệu năng camera cùng viên pin cực khủng so với Nokia C20 đem lại trải nghiệm tuyệt vời hơn thế hệ tiền nhiệm của mình.
', 6)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (43, N'Nokia 5710
', 1790000, N'sp43.jpg', 50, N'Bên cạnh sự phát triển của điện thoại thông minh thì điện thoại phổ thông cũng không hề kém cạnh khi xuất hiện ngày càng nhiều kiểu thiết kế độc đáo. Cụ thể như chiếc Nokia 5710 - máy được trang bị tai nghe không dây ngay tại mặt lưng, điều này giúp máy không chỉ dành cho nghe gọi mà còn có thể hoạt động như một thiết bị nghe nhạc.
', 6)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (44, N'Nokia 8210 4G
', 1590000, N'sp44.jpg', 50, N'Nokia 8210 4G có lẽ là một lựa chọn phù hợp với những ai cần cho mình một chiếc điện thoại phổ thông phục vụ cho nhu cầu nghe gọi. Máy có giá thành rẻ và vừa có độ bền cao, giúp cho người dùng có thể tiết kiệm được kha khá số tiền bỏ ra ban đầu cũng như không cần quá lo lắng đến vấn đề hỏng hóc trong lúc sử dụng.
', 6)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (45, N'Nokia 215 4G
', 990000, N'sp45.jpg', 50, N'Nokia 215 4G chiếc điện thoại phổ thông ngoài các chức năng cơ bản thì máy đã được nâng cấp với sự hỗ trợ kết nối mạng 4G mang đến nhiều trải nghiệm hơn cho người dùng.
', 6)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (46, N'Vivo Y35

', 6290000, N'sp46.jpg', 50, N'Tiếp nối sự thành công của các mẫu smartphone tầm trung tại thị trường Việt Nam thì mới đây Vivo đã chính thức cho ra mắt điện thoại Vivo Y35. Máy sở hữu cho mình khả năng sạc siêu nhanh 44 W, cụm camera đem đến những bức ảnh sắc nét và một hiệu năng ổn định trong phân khúc.
', 7)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (47, N'Vivo V25 series

', 9490000, N'sp47.jpg', 50, N'Dường như 2022 là một năm bùng nổ cho điện thoại V series khi nhiều sản phẩm được cho ra mắt với thông số và thiết kế rất ấn tượng, trong đó có Vivo V25 vừa được giới thiệu vào tháng 10/2022 hứa hẹn sẽ gây sốt trên thị trường công nghệ trong giai đoạn cuối năm nay nhờ tạo hình đẹp cùng hiệu năng mạnh mẽ.
', 7)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (48, N'Vivo Y16

', 3790000, N'sp48.jpg', 50, N'Vivo Y16 64GB tiếp tục sẽ là cái tên được hãng bổ sung cho bộ sưu tập điện thoại Vivo dòng Y trong thời điểm cuối năm 2022, với mục tiêu mang đến nhiều trải nghiệm tốt hơn đối với dòng sản phẩm giá rẻ, Vivo hứa hẹn sẽ mang lại cho người dùng những trải nghiệm vượt xa mong đợi nhờ việc trang bị nhiều công nghệ xịn sò.
', 7)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (49, N'Vivo Y02s 32GB

', 3290000, N'sp49.jpg', 50, N'Vivo Y02s - một cái tên thuộc dòng Y vừa được Vivo ra mắt với một diện mạo trẻ trung. Sở hữu bộ thông số được xem là nổi bật trong phân khúc điện thoại giá rẻ hiện nay (08/2022). Đây hứa hẹn sẽ là sản phẩm “vừa ngon vừa rẻ” mà người dùng không nên bỏ qua.
', 7)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Picture], [Quantity], [Description], [ProdCateID]) VALUES (50, N'Vivo Y21 series

', 3290000, N'sp50.jpg', 50, N'Vivo Y21 chiếc smartphone mang trong mình nhiều ưu điểm nổi bật như màn hình viền mỏng đẹp mắt, hiệu năng ổn định cùng dung lượng pin tận 5000 mAh chắc chắn sẽ đáp ứng nhu cầu sử dụng của bạn cả ngày dài.
', 7)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[ProductBill] ([ProductID], [BillID], [Quantity]) VALUES (1, 1, 1)
INSERT [dbo].[ProductBill] ([ProductID], [BillID], [Quantity]) VALUES (3, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (1, N'Iphone', N'IMG-20240709210252.png')
INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (2, N'Samsung', N'IMG-20240709210212.png')
INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (3, N'Xiaomi', N'IMG-20240709210222.png')
INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (4, N'Oppo', N'IMG-20240709132847.jpg')
INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (5, N'Realme', N'IMG-20240709210241.png')
INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (6, N'Nokia', N'IMG-20240709210231.png')
INSERT [dbo].[ProductCategory] ([ProdCateID], [ProdCateName], [linkImage]) VALUES (7, N'Vivo', N'IMG-20240709210304.png')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp11.jpg', N'Vàng ', 1)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp12.jpg', N'Đen', 1)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp13.jpg', N'Bạc', 1)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp14.jpg', N'Tím', 1)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp21.jpg', N'Vàng ', 2)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp22.jpg', N'Đen', 2)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp23.jpg', N'Bạc', 2)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp24.jpg', N'Tím', 2)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp31.png', N'Trắng', 3)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp32.jpg', N'Tím ', 3)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp33.jpg', N'Đỏ', 3)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp41.jpg', N'Tím nhạt', 4)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp42.jpg', N'Đỏ', 4)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp51.jpg', N'Đen', 5)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp52.jpg', N'Trắng', 5)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp61.jpg', N'Xanh dương', 6)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp62.jpg', N'Xanh lá', 6)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp71.jpg', N'Tím nhạt', 7)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp72.jpg', N'Đen', 7)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp81.jpg', N'Xanh lá', 8)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp82.jpg', N'Xám', 8)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp91.jpg', N'Xanh', 9)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp92.jpg', N'Tím nhạt', 9)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp101.jpg', N'Cam', 10)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp102.jpg', N'Đen', 10)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp111.jpg', N'Xanh lá', 11)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp112.jpg', N'Xanh dương', 11)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp121.jpg', N'Kem', 12)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp122.jpg', N'Xanh', 12)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp131.jpg', N'Kem', 13)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp132.jpg', N'Đen', 13)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp141.jpg', N'Đen ', 14)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp142.jpg', N'Nâu', 14)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp151.jpg', N'Xanh rêu', 15)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp152.jpg', N'Đen', 15)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp161.jpg', N'Đỏ', 16)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp162.jpg', N'Trắng', 16)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp171.png', N'Xanh', 17)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp172.png', N'Đen', 17)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp181.jpg', N'Xanh dương nhạt', 18)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp191.jpg', N'Vàng ', 19)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp192.jpg', N'Đen', 19)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp201.jpg', N'Đen', 20)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp202.jpg', N'Bạc', 20)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp211.jpg', N'Đen', 21)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp212.jpg', N'Xanh lá', 21)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp221.jpg', N'Trắng', 22)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp231.jpg', N'Xanh dương', 23)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp232.jpg', N'Xám', 23)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp241.jpg', N'Xám', 24)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp242.jpg', N'Xanh dương', 24)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/so251.jpg', N'Xanh dương', 25)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp252.jpg', N'Trắng', 25)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp261.jpg', N'Xám', 26)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp262.jpg', N'Xanh lá', 26)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp271.jpg', N'Vàng đồng', 27)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp272.jpg', N'Đen', 27)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp281.jpg', N'Xanh ngọc', 28)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp282.jpg', N'Đen', 28)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp291.jpg', N'Xanh lá', 29)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp292.jpg', N'Đen', 29)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp301.jpg', N'Đen nhãn', 30)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp302.jpg', N'Xanh dương', 30)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp311.jpg', N'Đen', 31)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp312.jpg', N'Trắng', 31)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp321.jpg', N'Xanh ', 32)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp322.jpg', N'Đen', 32)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp331.jpg', N'Trắng', 33)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp332.jpg', N'Đen', 33)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/341.jpg', N'Xanh dương', 34)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp351.jpg', N'Vàng ', 35)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp352.jpg', N'Đen', 35)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp361.jpg', N'Vàng ', 36)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp362.jpg', N'Trắng', 36)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp371.png', N'Vàng', 37)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp381.jpg', N'Xanh dương', 38)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp391.jpeg', N'Xám', 39)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp392.jpg', N'Xanh dương', 39)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp401.jpg', N'Xám ', 40)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp402.jpg', N'Xanh dương', 40)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp411.jpg', N'Xám', 41)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp421.jpg', N'Xanh đậm', 42)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp422.jpg', N'Xanh mint', 42)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp431.jpg', N'Xanh dương', 43)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp432.jpg', N'Xám', 43)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp441.jpg', N'Trắng', 44)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp442.jpg', N'Đen', 44)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp451.jpg', N'Trắng', 45)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp452.jpg', N'Xanh', 45)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp461.jpg', N'Đen', 46)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp462.jpg', N'Vàng', 46)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp471.jpg', N'Vàng', 47)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp472.jpg', N'Đen', 47)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp481.jpg', N'Vàng', 48)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp482.jpg', N'Đen', 48)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp491.jpg', N'Xanh', 49)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp492.jpg', N'Đen', 49)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp501.jpg', N'Trắng', 50)
INSERT [dbo].[ProductImage] ([ImageLink], [Name], [ProductID]) VALUES (N'products/sp502.jpg', N'Xanh tím', 50)
GO
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (1, N'OLED 6.7" Super Retina XDR', N'iOS 16', N'Chính 48 MP & Phụ 12 MP, 12 MP', N'12 MP', N'Apple A16 Bionic', N'6 GB', N'128 GB', N'1 Nano SIM & 1 eSIM Hỗ trợ 5G', N'4323 mAh 20 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (2, N'OLED 6.1" Super Retina XDR', N'iOS 16', N'Chính 48 MP & Phụ 12 MP, 12 MP', N'12 MP', N'Apple A16 Bionic', N'6 GB', N'128 GB', N'1 Nano SIM & 1 eSIM Hỗ trợ 5G', N'3200 mAh 20 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (3, N'IPS LCD 6.1" Liquid Retina', N'iOS 15', N'2 camera 12 MP', N'12 MP', N'Apple A13 Bionic', N'4 GB', N'64 GB', N'1 Nano SIM & 1 eSIM Hỗ trợ 4G', N'3110 mAh 18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (4, N'OLED 6.1" Super Retina XDR', N'iOS 15', N'2 camera 12 MP', N'12 MP', N'Apple A14 Bionic', N'4 GB', N'64 GB', N'1 Nano SIM & 1 eSIM Hỗ trợ 5G', N'2815 mAh 20 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (5, N'OLED 6.1" Super Retina XDR', N'iOS 15', N'2 camera 12 MP', N'12 MP', N'Apple A14 Bionic', N'4 GB', N'128 GB', N'1 Nano SIM & 1 eSIM Hỗ trợ 4G', N'3240 mAh 20 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (6, N'OLED 6.7" Super Retina XDR', N'iOS 16', N'2 camera 12 MP', N'12 MP', N'Apple A15 Bionic', N'6 GB', N'128 GB', N'1 Nano SIM & 1 eSIM Hỗ trợ 5G', N'4325 mAh 20 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (7, N'Dynamic AMOLED 2X6.1"Full HD+', N'Android 13', N'Chính 50 MP & Phụ 12 MP, 10 MP', N'12 MP', N'Snapdragon 8 Gen 2 8 nhân', N'8 GB', N'128 GB', N'2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G', N'3900 mAh 25 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (8, N'Dynamic AMOLED 2X6.4"Full HD+', N'Android 12', N'Chính 12 MP & Phụ 12 MP, 8 MP', N'32 MP', N'Exynos 2100', N'6 GB', N'128 GB', N'2 Nano SIMHỗ trợ 5G', N'4500 mAh 25 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (9, N'Dynamic AMOLED 2X6.8"Quad HD+ (2K+)', N'Android 13', N'Chính 200 MP & Phụ 12 MP, 10 MP, 10 MP', N'12 MP', N'Snapdragon 8 Gen 2 8 nhân', N'8 GB', N'256 GB', N'2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G', N'5000 mAh 45 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (10, N'PLS TFT LCD 6.6" Full HD+', N'Android 12', N'Chính 50 MP & Phụ 5 MP, 2 MP, 2 MP', N'8 MP', N'Snapdragon 680', N'4 GB', N'128 GB', N'2 Nano SIM Hỗ trợ 4G', N'5000 mAh 25 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (11, N'Super AMOLED 6.5" Full HD+', N'Android 12', N'Chính 12 MP & Phụ 12 MP, 8 MP', N'32 MP', N'Snapdragon 865', N'8 GB', N'256 GB', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 4G', N'4500 mAh 25 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (12, N'Dynamic AMOLED 2X 6.6" Full HD+', N'Android 13', N'Chính 50 MP & Phụ 12 MP, 10 MP', N'12 MP', N'Snapdragon 8 Gen 2 8 nhân', N'8 GB', N'256 GB', N'2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G', N'4700 mAh 45 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (13, N'Dynamic AMOLED 2XChính 7.6" & Phụ 6.2"Quad HD+ (2K+)', N'Android 12', N'Chính 50 MP & Phụ 12 MP, 10 MP', N'10 MP & 4 MP', N'Snapdragon 8+ Gen 1', N'12 GB', N'256 GB', N'1 Nano SIM & 1 eSIMHỗ trợ 5G', N'4400 mAh 25 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (14, N'IPS LCD 6.5" HD+', N'Android 12', N'Chính 50 MP & Phụ 2 MP, 2 MP', N'5 MP', N'Exynos 850', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh 15 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (15, N'Dynamic AMOLED 2XChính 7.6"  & Phụ 6.2" Full HD+', N'Android 11', N'3 camera 12 MP', N'10 MP & 4 MP', N'Snapdragon 888', N'12 GB', N'512 GB', N'2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G', N'4400 mAh 25 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (16, N'Dynamic AMOLED 2X6.8"Quad HD+ (2K+)', N'Android 12', N'Chính 108 MP & Phụ 12 MP, 10 MP, 10 MP', N'40 MP', N'Snapdragon 8 Gen 1', N'8 GB', N'128 GB', N'2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G', N'5000 mAh 45 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (17, N'IPS LCD 6.71" HD+', N'Android 13', N'50 MP', N'5 MP', N'MediaTek Helio G85', N'4 GB', N'128 GB', N' 2 Nano SIMHỗ trợ 4G', N' 5000 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (18, N'AMOLED6.43"Full HD+', N'Android 11', N'Chính 50 MP & Phụ 8 MP, 2 MP, 2 MP', N'13 MP', N'Snapdragon 680', N'4 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh 33 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (19, N'IPS LCD6.71"HD+', N'Android 11', N'Chính 13 MP & Phụ 2 MP', N'5 MP', N'JLQ JR510', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'6000 mAh18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (20, N'AMOLED6.67"1.5K', N'Android 12', N'Chính 108 MP & Phụ 8 MP, 2 MP', N'20 MP', N'MediaTek Dimensity 8100 Ultra 8 nhân', N'8 GB', N'128 GB', N'2 Nano SIMHỗ trợ 5G', N'5000 mAh 120 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (21, N'AMOLED6.36"Full HD+', N'Android 13', N'Chính 50 MP & Phụ 12 MP, 10 MP', N'32 MP', N'Snapdragon 8 Gen 2 8 nhân', N'8 GB', N'256 GB', N'2 Nano SIMHỗ trợ 5G', N'4500 mAh 67 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (22, N'AMOLED6.67"Full HD+', N'Android 11', N'Chính 108 MP & Phụ 8 MP, 2 MP, 2 MP', N'16 MP', N'MediaTek Helio G96', N'8 GB', N'128 GB', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 4G', N'5000 mAh 67 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (23, N'AMOLED6.43"Full HD+', N'Android 11', N'Chính 108 MP & Phụ 8 MP, 2 MP, 2 MP', N'16 MP', N'MediaTek Helio G96', N'8 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh 33 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (24, N'IPS LCD6.5"Full HD+', N'Android 11', N'Chính 50 MP & Phụ 8 MP, 2 MP, 2 MP', N'8 MP', N'MediaTek Helio G88', N'4 GB', N'128 GB', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 4G', N'5000 mAh 18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (25, N'IPS LCD6.71"HD+', N'Android 11', N'Chính 50 MP & Phụ 2 MP', N'5 MP', N'Snapdragon 680', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh 18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (26, N'IPS LCD6.53"HD+', N'Android 11', N'Chính 13 MP & Phụ 2 MP', N'5 MP', N'MediaTek Helio G25', N'2 GB', N'32 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh 10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (27, N'AMOLED6.7"Full HD+', N'Android 13', N'Chính 108 MP & Phụ 2 MP, 2 MP', N'32 MP', N'Snapdragon 695 5G', N'8 GB', N'256 GB', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 5G', N'4800 mAh 67 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (28, N'AMOLED6.7"Full HD+', N'Android 12', N'Chính 50 MP & Phụ 8 MP, 2 MP', N'32 MP', N'MediaTek Dimensity 8100 Max 8 nhân', N'12 GB', N'256 GB', N'2 Nano SIMHỗ trợ 5G', N'4500 mAh 80 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (29, N'IPS LCD6.5"HD+', N'Android 11', N'Chính 50 MP & Phụ 2 MP, 2 MP', N'16 MP', N'MediaTek Helio G35', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (30, N'IPS LCD6.52"HD+', N'Android 11', N'13 MP', N'5 MP', N'MediaTek Helio G35', N'3 GB', N'32 GB', N' 2 Nano SIMHỗ trợ 4G', N'4230 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (31, N'AMOLED6.7"Quad HD+ (2K+)', N'Android 12', N'Chính 50 MP & Phụ 50 MP, 13 MP', N'32 MP', N'Snapdragon 8 Gen 1', N'12 GB', N'256 GB', N'2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G', N'5000 mAh80 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (32, N'IPS LCD6.5"HD+', N'Android 12 (Go Edition)', N'8 MP', N'5 MP', N'Unisoc SC9863A1', N'2 GB', N'32 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh 10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (33, N'IPS LCD 6.72" Full HD+', N'Android 13', N'Chính 64 MP & Phụ 2 MP', N'8 MP', N'MediaTek Helio G88', N'6 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N' 5000 mAh33 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (34, N'Super AMOLED6.4"Full HD+', N'Android 12', N'Chính 50 MP & Phụ 8 MP, 2 MP', N'16 MP', N'MediaTek Dimensity 920 5G', N'8 GB', N'128 GB', N'2 Nano SIMHỗ trợ 5G', N'4500 mAh60 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (35, N'Super AMOLED6.4"Full HD+', N'Android 11', N'Chính 108 MP & Phụ 8 MP, 2 MP, 2 MP', N'16 MP', N'Snapdragon 720G', N'8 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N'4500 mAh50 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (36, N'Super AMOLED6.4"Full HD+', N'Android 12', N'Chính 108 MP & Phụ 8 MP, 2 MP', N'16 MP', N'Snapdragon 680', N'8 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh33 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (37, N' IPS LCD 6.72" Full HD+', N'Android 13', N'Chính 64 MP & Phụ 2 MP', N'8 MP', N'MediaTek Helio G88', N'6 GB', N'128 GB', N' 2 Nano SIMHỗ trợ 4G', N' 5000 mAh33 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (38, N'IPS LCD6.5"HD+', N'Android 11', N'Chính 50 MP & Phụ 2 MP, 2 MP', N'8 MP', N'Unisoc T618', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (39, N'TFT LCD6.5"HD+', N'Android 11 (Go Edition)', N'Chính 13 MP & Phụ 2 MP', N'5 MP', N'Spreadtrum SC9863A', N'3 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5050 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (40, N'TFT LCD', N'Android 12', N'Chính 50 MP ', N' Phụ 2 MP, 2 MP', N'Unisoc T606', N'4 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N'5050 mAh')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (41, N'TFT LCD6.5"HD+', N'Android 11', N'Chính 13 MP & Phụ 2 MP, 2 MP', N'8 MP', N'Unisoc T606', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5050 mAh18 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (42, N'TFT LCD6.7"HD+', N'Android 12', N'Chính 13 MP & Phụ 2 MP, 2 MP', N'5 MP', N'Unisoc SC9863A1', N'3 GB', N'32 GB', N'2 Nano SIMHỗ trợ 4G', N'5050 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (43, N'TFT LCD6.51"HD+', N'Android 12', N'Chính 50 MP & Phụ 2 MP', N'8 MP', N'Unisoc T606', N'3 GB', N'32 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (44, N'2.8"', N'Android 5', N'0.3 MP', N'null', N'null', N'1GB', N'1GP', N'2 Nano SIMHỗ trợ 4G', N'1450 mAh')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (45, N'TFT LCD2.4"256.000 màu', N'Android', N'null', N'null', N'null', N'1GB', N'1GB', N'2 Nano SIMHỗ trợ 4G', N'1150 mAh')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (46, N'IPS LCD6.58"Full HD+', N'Android 12', N'Chính 50 MP & Phụ 2 MP, 2 MP', N'16 MP', N'Snapdragon 680', N'8 GB', N'128 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh44 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (47, N'AMOLED6.44"Full HD+', N'Android 12', N'Chính 64 MP & Phụ 8 MP, 2 MP', N'50 MP', N'MediaTek Dimensity 900 5G', N'8 GB', N'128 GB', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 5G', N'4500 mAh44 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (48, N'IPS LCD6.51"HD+', N'Android 12', N'Chính 13 MP & Phụ 2 MP', N'5 MP', N'MediaTek Helio P35', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (49, N'IPS LCD6.51"HD+', N'Android 12', N'8 MP', N'5 MP', N'MediaTek Helio P35', N'3 GB', N'32 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh10 W')
INSERT [dbo].[ProductInfo] ([ProductID], [Screen], [OS], [FrontCam], [BackCam], [Chip], [Ram], [Storage], [SIM], [Battery]) VALUES (50, N'IPS LCD6.51"HD+', N'Android 11', N'Chính 13 MP & Phụ 2 MP', N'8 MP', N'MediaTek Helio P35', N'4 GB', N'64 GB', N'2 Nano SIMHỗ trợ 4G', N'5000 mAh18 W')
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName], [RoleDescription]) VALUES (1, N'Admin', N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName], [RoleDescription]) VALUES (2, N'User', N'User')
INSERT [dbo].[Role] ([RoleId], [RoleName], [RoleDescription]) VALUES (3, N'Employee', N'trống')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([UserID], [Account], [Password], [ForgotPassowrd], [RoleId]) VALUES (1, N'admin', N'123123', N'', 1)
INSERT [dbo].[TaiKhoan] ([UserID], [Account], [Password], [ForgotPassowrd], [RoleId]) VALUES (2, N'trongnguyen.02.stu@gmail.com', N'222222', N'', 2)
INSERT [dbo].[TaiKhoan] ([UserID], [Account], [Password], [ForgotPassowrd], [RoleId]) VALUES (8, N'employee@gmail.com', N'123123', N'', 3)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[Voucher] ON 

INSERT [dbo].[Voucher] ([VoucherID], [DateStarted], [DateEnded], [Code], [PriceSale], [UseTimess]) VALUES (6, CAST(N'2024-07-14T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-16T00:00:00.0000000' AS DateTime2), N'voucherz', 0, 2)
INSERT [dbo].[Voucher] ([VoucherID], [DateStarted], [DateEnded], [Code], [PriceSale], [UseTimess]) VALUES (7, CAST(N'2024-07-14T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-15T00:00:00.0000000' AS DateTime2), N'zxcvbn', 10000, 2)
SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO
/****** Object:  Index [IX_Bill_CustomerID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bill_CustomerID] ON [dbo].[Bill]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bill_EmployeeID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bill_EmployeeID] ON [dbo].[Bill]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bill_VoucherID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bill_VoucherID] ON [dbo].[Bill]
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_ProdCateID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_ProdCateID] ON [dbo].[Product]
(
	[ProdCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductBill_BillID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductBill_BillID] ON [dbo].[ProductBill]
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImage_ProductID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImage_ProductID] ON [dbo].[ProductImage]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSale_ProductID]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSale_ProductID] ON [dbo].[ProductSale]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaiKhoan_RoleId]    Script Date: 7/15/2024 12:27:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaiKhoan_RoleId] ON [dbo].[TaiKhoan]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory_ProdCateID] FOREIGN KEY([ProdCateID])
REFERENCES [dbo].[ProductCategory] ([ProdCateID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory_ProdCateID]
GO
ALTER TABLE [dbo].[ProductBill]  WITH CHECK ADD  CONSTRAINT [FK_ProductBill_Bill_BillID] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([BillID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductBill] CHECK CONSTRAINT [FK_ProductBill_Bill_BillID]
GO
ALTER TABLE [dbo].[ProductBill]  WITH CHECK ADD  CONSTRAINT [FK_ProductBill_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductBill] CHECK CONSTRAINT [FK_ProductBill_Product_ProductID]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product_ProductID]
GO
ALTER TABLE [dbo].[ProductInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProductInfo_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInfo] CHECK CONSTRAINT [FK_ProductInfo_Product_ProductID]
GO
ALTER TABLE [dbo].[ProductSale]  WITH CHECK ADD  CONSTRAINT [FK_ProductSale_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSale] CHECK CONSTRAINT [FK_ProductSale_Product_ProductID]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_Role_RoleId]
GO
USE [master]
GO
ALTER DATABASE [PhoneS] SET  READ_WRITE 
GO
