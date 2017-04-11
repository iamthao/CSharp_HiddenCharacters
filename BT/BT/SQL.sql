USE [Dienmay]
GO
/****** Object:  Table [dbo].[Nhomsanpham]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhomsanpham](
	[Id] [int] NOT NULL,
	[Tennhomsp] [nvarchar](100) NULL,
 CONSTRAINT [PK_Nhomsanpham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Nhomsanpham] ([Id], [Tennhomsp]) VALUES (1, N'Điện Tử')
INSERT [dbo].[Nhomsanpham] ([Id], [Tennhomsp]) VALUES (2, N'Điện Lạnh')
INSERT [dbo].[Nhomsanpham] ([Id], [Tennhomsp]) VALUES (3, N'Vi Tính')
INSERT [dbo].[Nhomsanpham] ([Id], [Tennhomsp]) VALUES (4, N'Di Động')
INSERT [dbo].[Nhomsanpham] ([Id], [Tennhomsp]) VALUES (5, N'Viễn Thông')
INSERT [dbo].[Nhomsanpham] ([Id], [Tennhomsp]) VALUES (6, N'Gia Dụng')
/****** Object:  Table [dbo].[Trangthaihoadon]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trangthaihoadon](
	[Id] [int] NOT NULL,
	[Tentthd] [nvarchar](100) NULL,
 CONSTRAINT [PK_Trangthaihoadon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Trangthaihoadon] ([Id], [Tentthd]) VALUES (1, N'Chưa Liên Lạc')
INSERT [dbo].[Trangthaihoadon] ([Id], [Tentthd]) VALUES (2, N'Chưa Giao')
INSERT [dbo].[Trangthaihoadon] ([Id], [Tentthd]) VALUES (3, N'Đã Giao')
/****** Object:  Table [dbo].[Nhacungcap]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhacungcap](
	[Id] [int] NOT NULL,
	[Tenncc] [nvarchar](100) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
 CONSTRAINT [PK_Nhacungcap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Nhacungcap] ([Id], [Tenncc], [Diachi], [SDT]) VALUES (1, N'Công Ty TNHH ABCD', N'192 Hàm Tử Phường 1 Quận 5 Tp HCM', N'39876761')
INSERT [dbo].[Nhacungcap] ([Id], [Tenncc], [Diachi], [SDT]) VALUES (2, N'Công Ty Cổ Phần CBC', N'190 Chương Dương Phường 2 Quận 9 Tp HCM', N'39245638')
/****** Object:  Table [dbo].[Loainhanvien]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loainhanvien](
	[Id] [int] NOT NULL,
	[Tenloainv] [nvarchar](100) NULL,
 CONSTRAINT [PK_Loainhanvien] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Loainhanvien] ([Id], [Tenloainv]) VALUES (1, N'Admin')
INSERT [dbo].[Loainhanvien] ([Id], [Tenloainv]) VALUES (2, N'Kinh Doanh')
INSERT [dbo].[Loainhanvien] ([Id], [Tenloainv]) VALUES (3, N'Kế Toán')
INSERT [dbo].[Loainhanvien] ([Id], [Tenloainv]) VALUES (4, N'Bán Hàng')
/****** Object:  Table [dbo].[Loaikhachhang]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaikhachhang](
	[Id] [int] NOT NULL,
	[Tenloaikh] [nvarchar](100) NULL,
 CONSTRAINT [PK_Loaikhachhang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Loaikhachhang] ([Id], [Tenloaikh]) VALUES (1, N'Khách Hàng Thường')
INSERT [dbo].[Loaikhachhang] ([Id], [Tenloaikh]) VALUES (2, N'Khách Hàng Thân Thiết')
INSERT [dbo].[Loaikhachhang] ([Id], [Tenloaikh]) VALUES (3, N'Khách Hàng VIP')
/****** Object:  Table [dbo].[Kho]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[Id] [int] NOT NULL,
	[Tenkho] [nvarchar](100) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Kho] ([Id], [Tenkho], [Diachi], [SDT]) VALUES (1, N'Kho I', N'102 Nguyễn Thị Minh Khai Phường 1 Quận 1 Tp HCM', N'39865676')
/****** Object:  Table [dbo].[Khachhang]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[Id] [int] NOT NULL,
	[Tenkh] [nvarchar](100) NULL,
	[Ngaysinh] [date] NULL,
	[Gioitinh] [nvarchar](3) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[CMND] [nvarchar](20) NULL,
	[Ghichu] [nvarchar](2000) NULL,
	[Username] [nvarchar](15) NULL,
	[Password] [nvarchar](15) NULL,
	[LoaikhachhangId] [int] NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Khachhang] ([Id], [Tenkh], [Ngaysinh], [Gioitinh], [Diachi], [SDT], [Email], [CMND], [Ghichu], [Username], [Password], [LoaikhachhangId]) VALUES (1, N'Khách Hàng I', CAST(0xC3190B00 AS Date), N'Nam', N'Khách Hàng I', N'123456789', N'username@gmail.com', N'123456789', N'', N'username', N'username', 1)
INSERT [dbo].[Khachhang] ([Id], [Tenkh], [Ngaysinh], [Gioitinh], [Diachi], [SDT], [Email], [CMND], [Ghichu], [Username], [Password], [LoaikhachhangId]) VALUES (2, N'Khách Hàng II', CAST(0xDE190B00 AS Date), N'Nữ', N'Khách Hàng II', N'987654321', N'user@gmail.com', N'987654321', N'', N'user', N'user', 1)
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[Id] [int] NOT NULL,
	[Tennv] [nvarchar](100) NULL,
	[Ngaysinh] [date] NULL,
	[Gioitinh] [nvarchar](3) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[CMND] [nvarchar](20) NULL,
	[Ngayvaolam] [date] NULL,
	[Username] [nvarchar](15) NULL,
	[Password] [nvarchar](15) NULL,
	[LoainhanvienId] [int] NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaisanpham]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaisanpham](
	[Id] [int] NOT NULL,
	[Tenloaisp] [nvarchar](100) NULL,
	[NhomspId] [int] NULL,
 CONSTRAINT [PK_Loaisanpham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (1, N'Tivi', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (2, N'Dàn Máy', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (3, N'Đầu DVD', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (4, N'Đầu Karaoke', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (5, N'Loa', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (6, N'Amply', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (7, N'Micro', 1)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (8, N'Tủ Lạnh', 2)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (9, N'Máy Giặt', 2)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (10, N'Máy Sấy', 2)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (11, N'Máy Rửa Chén', 2)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (12, N'Máy Nước Nóng', 2)
INSERT [dbo].[Loaisanpham] ([Id], [Tenloaisp], [NhomspId]) VALUES (13, N'Máy Lọc Không Khí', 2)
/****** Object:  Table [dbo].[Xuathang]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xuathang](
	[Id] [int] NOT NULL,
	[KhoId] [int] NULL,
	[NhanvienId] [int] NULL,
	[Ngayxuat] [date] NULL,
	[Ghichu] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Xuathang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[Id] [int] NOT NULL,
	[Tensp] [nvarchar](100) NULL,
	[Tinhnangchinh] [nvarchar](2000) NULL,
	[Chitiet] [nvarchar](2000) NULL,
	[Hinh] [nvarchar](200) NULL,
	[Ngayban] [date] NULL,
	[LoaisanphamId] [int] NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (1, N'Amply Denon', N'Bộ giải mã âm thanh:Dolby Digital, Dolby Pro Logic IIz, Dolby TrueHD. Công suất ngõ ra: 125W x 7 kênh. Hiệu ứng âm thanh: DSP, Jazz Club Surround, Matrix Surround, Rock Arena Surround, Virtual Surround. 3D Pass Through: Có', N'Hệ Thống Âm Thanh. Bộ giải mã âm thanh:Dolby Digital, Dolby Pro Logic IIz, Dolby TrueHD. Điều chỉnh âm thanh tự động: Đang cập nhật. Hiệu ứng âm thanh: DSP, Jazz Club Surround, Matrix Surround, Rock Arena Surround, Virtual Surround. 3D Pass Through: Có. Cổng Kết Nối. Ngõ vào HDMI: 4. Ngõ ra HDMI: 1. Ngõ vào Component video: 1. Ngõ vào front-Panel A/V: Có. Thông Số Kỹ Thuật. Công suất ngõ ra: 125W x 7 kênh. Số kênh: 7.1. Trở kháng đầu vào (Ω): Đang cập nhật', N'~/Content/Img/Product/AMP2.jpg', CAST(0xDE370B00 AS Date), 6, 1500000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (2, N'Amply Kiti', N'Sử dụng 12 Domino Toshiba. Công Suất Tối Đa 800W. Chức năng Speaker A – B. Đèn hiển thị VFD cao cấp. Mạch bảo vệ loa', N'Thông Tin Sản Phẩm. Sử dụng 12 Domino Toshiba. Công Suất Tối Đa 800W. Chức năng Speaker A – B. Đèn hiển thị VFD cao cấp. Mạch bảo vệ loa. Lắp Ráp : Việt Nam. Bảo Hành 12 Tháng', N'~/Content/Img/Product/AMP3.jpg', CAST(0xDE370B00 AS Date), 6, 2000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (3, N'Dàn Máy LG', N'Công suất: 300W. Bộ xử lý âm thanh: DTS, Dolby Digital, Dolby Prologic. Số loa: 5 + 1 loa siêu trầm. Hỗ trợ định dạng CD, CD-R, CD-RW, DVD, DVD-R, DVD-RW. Kết nối USB 2.0', N'Thông Số Cơ Bản. Loại Sản Phẩm : Home Theatre System. Kênh : 5.1. Công Suất. Công Suất - Tổng : 300W. Công Suất - Loa Trước : 45W+45W. Công Suất - Loa Trung Tâm : 45W. Công Suất - Loa Vệ Tinh : 45W+45W. Công Suất - Loa Siêu Trầm : 75W. Âm Thanh. Dolby Pro Logic II : Có. Dolby Digital/Dolby Digital + : Có. BassBoost : Có. MP3 / Mp3 ID3 Tag : Có. WMA : Có. Hình Ảnh. Video - MPEG2 : Có. Video - MPEG4 AVC(H.264) : Có. Video - DivX : Có', N'~/Content/Img/Product/DM3.jpg', CAST(0xDE370B00 AS Date), 2, 5000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (4, N'Đầu DVD Oppo', N'Hỗ trợ các loại đĩa: DVD, SVCD, CD, DVD+RW, DVD-RW, CD-R, CD-RW, WMA, HDCD, Và file định dạng OGG, JPGE. Cổng cấm USB 2.0. Bộ giải mã tích hợp Dolbay Digital. Có khả năng chống bụi và chống Oxi hóa', N'Hỗ trợ các loại đĩa: DVD, SVCD, CD, DVD+RW, DVD-RW, CD-R, CD-RW, WMA, HDCD, Và file định dạng OGG, JPGE. Video DAC 108 MGz/12bit, hình ảnh sống động trung thực. Cổng cấm USB 2.0 đường truyền tốc độ cao, đọc các file đa âm. Bộ giải mã tích hợp Dolbay Digital, tín hiệu đầu ra 2 kênh riêng biệt. Giải điện áp rộng ~100V - 240V, 50/60Hz. Có khả năng chống bụi và chống Oxi hóa. Bảo hành 12 tháng. Xuất xứ Trung quốc', N'~/Content/Img/Product/DVD3.jpg', CAST(0xDF370B00 AS Date), 3, 1000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (5, N'Đầu Karaoke Ariang', N'Định dạng đĩa : CD,DVD,MP3,MPEG-2,MPEG-4. Chấm điểm chuyên nghiệp. Thiết kế đẹp, sang trọng với 3 màu mạnh mẽ. Đặc biệt hỗ trợ hình nền Full HD, xem phim Full HD từ ổ cứng', N'Tính Năng Chính. Định dạng đĩa : CD,DVD,MP3,MPEG-2,MPEG-4. Chấm điểm chuyên nghiệp. Thiết kế đẹp, sang trọng với 3 màu mạnh mẽ. Sử dụng ổ DVD và ổ cứng bổ sung dung lượng lớn có thể mở rộng lên đến trên 2TB (2000GB), thỏa sức lưu trữ các bài hát MTV Karaoke. Đặc biệt hỗ trợ hình nền Full HD, xem phim Full HD từ ổ cứng', N'~/Content/Img/Product/KRO3.jpg', CAST(0xDF370B00 AS Date), 4, 900000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (6, N'Loa Boston', N'Kiểu dáng trang nhã. Âm thanh chuyên nghiệp. Công suất 120W - 4ohm. Công nghệ sản xuất theo tiêu chuẩn: Mỹ', N'Kiểu dáng trang nhã. Âm thanh chuyên nghiệp. Công suất 120W - 4ohm. Công nghệ sản xuất theo tiêu chuẩn: Mỹ. Sản xuất tại: Hàn Quốc. Bảo hành: 12 tháng', N'~/Content/Img/Product/LOA3.jpg', CAST(0xDF370B00 AS Date), 5, 2000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (7, N'Máy Giặt LG', N'Khối lượng giặt: 7.6 kg. Chương trình giặt nhanh 19''. Tự động khởi động lại khi có điện. Lưới chống chuột', N'Loại máy: lồng đứng. Khối lượng giặt: 7.6kg. Thiết kế sang trọng và lịch sự với nắp kính chịu lực, chịu nhiệt và chống xước. Vắt cực khô với các mức thời gian 60'', 90'' & 120''. Chi Tiết. Loại máy: lồng đứng. Khối lượng giặt: 7.6kg. Chương trình giặt nhanh 19''. Bộ lọc xơ vải nhựa bền đẹp và sạch sẽ. 6 thác nước tăng cường hiệu quả. Thiết kế sang trọng và lịch sự với nắp kính chịu lực, chịu nhiệt và chống xước. Vắt cực khô với các mức thời gian 60'', 90'' & 120''', N'~/Content/Img/Product/MG3.jpg', CAST(0xDF370B00 AS Date), 9, 4000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (8, N'Máy Lọc Không Khí Electrolux', N'Bộ lọc cacbon: vi khuẩn và xử lý mùi. Bộ lọc HEPA: loại bỏ bụi, phấn hoa,.... Bộ làm sạch UV: hủy diệt vi khuẩn, phân hủy mùi. Ion hóa: Cân bằng Ion trong không khí. Cảm ứng bụi và gas: có ', N'Sản phẩm: máy lọc không khí. Bộ lọc cacbon: kềm chế phát triển vi khuẩn và xử lý mùi. Bộ lọc HEPA: loại bỏ bụi, phấn hoa, mốc, chất gây di ứng. Bộ làm sạch UV: bắn tia sát trùng hủy diệt vi khuẩn, phân hủy mùi. Ion hóa: Cân bằng Ion trong không khí, làm không khí trong lành. Màu sắc: Đen. Trọng lượng: 8,5 kg. Công suất tiêu thụ: 123W. Điều kiện: tự động-thủ công. Cảm ứng bụi và gas: có. Hẹn giờ tự động: có. Hãng sản xuất: Electrolux. Xuất xứ: China. Bảo hành: 24 tháng ', N'~/Content/Img/Product/LKK1.jpg', CAST(0xDF370B00 AS Date), 13, 1500000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (9, N'Máy Nước Nóng Ariston', N'Hệ thống đun trực tiếp hiệu quả. Tuyệt đối an toàn với chức năng an toàn. Bộ van thiết kế 3-trong-1. Bộ thiết bị chống giật ELC. Tặng PMH Panasonic 500.000VND. Giá & quà áp dụng đến 01/11/2013', N'Hệ thống đun trực tiếp hiệu quả. Tuyệt đối an toàn các chức năng an toàn. Bộ thiết bị chống giật ELCB tích hợp 15mA. Bộ giới hạn nhiệt độ tại 550C chống quá nhiệt nhằm bảo vệ người tiêu dùng tốt nhất. Công tắc tiết lưu tự động ngăn ngừa sự quá nhiệt do tắc nghẽn đường ống. Tích hợp bộ điểu khiển nhiệt độ điện tử. Hợp chuẩn Châu Âu về thiết bị điện, điện tử. Bộ van thiết kế 3-trong-1: (khóa - lọc - mở). Phù hợp mọi điều kiện áp lực nước. Màu sắc đa dạng: lựa chọn phong phú phù hợp nhu cầu. Công suất (w): 4500. Điện thế (V) : 230. Cường độ dòng điện (A) : 20.5. Lưu lượng nước tối thiểu (lít/phút): 3. Lưu lượng nước tối đa (lít/phút) : 6. Đầu nối nước (Inch) : G1/2', N'~/Content/Img/Product/MNN1.jpg', CAST(0xDF370B00 AS Date), 12, 2000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (10, N'Máy Rửa Chén Candy', N'Màu sắc : Bạc. Kích thước: 600 x 600 x 850. Năng suất : 15 bộ đồ ăn. Điện áp: 230V-50Hzh. Công suất tiêu thụ trung bình : 1.1kWh. Lượng nước tiêu thụ: 13L/ lần rửa ', N'Thông Tin Sản Phẩm. Điện áp: 230V-50Hzh. Công suất tiêu thụ trung bình: 1.1kWh. Lượng nước tiêu thụ: 13L/ lần rửa. Có 12 chương trình rửa với nhiều cấp độ nhiệt độ. Rửa thông thường ở nhiệt độ 65oC những sản phẩm dễ vỡ, dụng cụ ít dầu mỡ. Rửa mạnh ở nhiệt độ 75oC giúp đánh bật các vết bẩn, dầu mỡ cứng đầu nhất. Có hệ thống khử nước cứng, hệ thống sấy khô ngưng tụ. Có tín hiệu báo kết thúc chương trình, có đèn báo khi sử dụng với muối. Hệ thống kệ giá bằng kim loại cực lớn, rổ linh động có thể điều chỉnh dễ dàng. Độ ồn thấp: 50 dBA. Đạt đẳng cấp: AAA (tiết kiệm điện, hiệu quả rửa cực sach và sấy khô tuyệt đối). Xuất Xứ & Bảo Hành. Xuất xứ: Italy. Bảo hành: 24 tháng', N'~/Content/Img/Product/MRC1.jpg', CAST(0xDF370B00 AS Date), 11, 6000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (11, N'Máy Sấy Candy', N'Loại sản phẩm: mấy sấy ngưng tụ. Khối lượng giặt: 8 kg. Cẩm biến ẩm: có. Làm nguội vải: có. Chức năng chống nhăn: có', N'Thông Số Và Chức Năng. Loại sản phẩm: mấy sấy ngưng tụ. Khối lượng giặt: 8 kg. Cẩm biến ẩm; có. Làm nguội vải: có. Chức năng chống nhăn: có. Mức độ sấy: 4 mức khô. Chương trình sấy: hỗ trợ nhiều loại vải. Quy trình sấy: đảo chiều. Mức tiêu thụ: 4,5 kW/chu kỳ. Thông Tin Bảo Hành. Hãng sản xuất: CANDY (Italia). Xuất xứ: Thỗ Nhĩ Kỳ. Bảo hành: 1 năm ', N'~/Content/Img/Product/MS1.jpg', CAST(0xDF370B00 AS Date), 10, 1200000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (12, N'Micro Guiness', N'Băng tần: UHF: dãy tần số: 740 - 860MHz F.R. Độ méo tiếng: ≤ 0.3 %. Công suất phát sóng: 30 mW. Đáp tuyến tần số : 45 Hz -> 15 KHz. Điện áp nguồn: 110V ~ 220V, 50Hz ', N'Thông Tin Nổi Bật. Băng tần: UHF: dãy tần số: 740 - 860MHz F.R. Độ méo tiếng: ≤ 0.3 %. Công suất phát sóng: 30 mW. Đáp tuyến tần số: 45 Hz -> 15 KHz. Điện áp nguồn: 110V ~ 220V, 50Hz – 60Hz. Thông Tin Sản Phẩm. Loại: Không dây. Độ méo tiếng: <= 0.3%. Tần số: 45 Hz - 15 KHz. Băng tần: UHF. Xuất Xứ & Bảo Hành. Bảo Hành: 12. Hãng sản xuất: Guinness', N'~/Content/Img/Product/MIC1.jpg', CAST(0xDF370B00 AS Date), 7, 1000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (13, N'Tivi Plasma 3D LG', N'Full HD 3D ,600Hz Sub-field Driving. Độ tương phản 3.000.000:1. Quét hình 600Hz Subfield Driving. Chuyển đổi hình ảnh từ 2D sang 3D. Sản Phẩm Giá Cạnh Tranh', N'Độ phân giải : 1920x1080. Độ sáng (cd/m2) : 1500. Độ Tương Phản Động : 3,000,000:1. Góc Nhìn : 178/178. Thời Gian Đáp Ứng (MPRT) : 0,001ms. WCC (Kiểm Soát Màu Rộng) : Có. FullHD :Có. 600Hz Sub-field Driving : Có. Tuổi Thọ (giờ) : 100,000h. Công Suất Âm Thanh : 10W. Hệ Thống Âm Thanh Vòm : SRS Trussuround. Chế độ lọc thoại Clear Voice II : Có. Bộ Chỉnh Mức Âm Lượng Thông Minh : Có. Đường Ăng ten vào : Có (1). AV Vào : Có (1). Component vào (Y,Pb,Pr) + Âm Thanh : Có (1). HDMI/HDCP Vào : Có (3). USB 2.0 : Có (2). RGB Vào (D-sub 15pin) : Có (1). PC Audio Vào : Có (1). Headphone out : Có. Đường ra âm thanh số (Optical) : Có', N'~/Content/Img/Product/TV3.jpg', CAST(0xDF370B00 AS Date), 1, 7000000)
INSERT [dbo].[Sanpham] ([Id], [Tensp], [Tinhnangchinh], [Chitiet], [Hinh], [Ngayban], [LoaisanphamId], [Gia]) VALUES (14, N'Tủ Lạnh LG', N'Loại Tủ: Tủ ba cánh. Tổng dung tích: 247lít. Không đóng tuyết. Hệ thống làm lạnh với dòng khí đa chiều. Các ngăn và kệ tháo lắp linh động', N'Hệ thống điều chỉnh độ ẩm. Chất liệu khay: Thủy tinh. Có chuông báo cửa. Có móc giỏ. Dung tích ngăn đông: 30 lít. Dung tích ngăn lạnh: 217 lít. Điện năng tiêu thụ: 128-152W. Luồng khí đa chiều. Trọng lượng: 45kg. Kích thước (RxSxC) 545 x 620 x 1729 mm. Hãng sản xuất: Electrolux. Xuất xứ: Thái Lan. Bảo hành: 02 Năm', N'~/Content/Img/Product/TL1.jpg', CAST(0xDF370B00 AS Date), 8, 3500000)
/****** Object:  Table [dbo].[Nhaphang]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhaphang](
	[Id] [int] NOT NULL,
	[KhoId] [int] NULL,
	[NhacungcapId] [int] NULL,
	[NhanvienId] [int] NULL,
	[Tongtien] [float] NULL,
	[Ngaynhap] [date] NULL,
	[Ghichu] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Nhaphang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[Id] [int] NOT NULL,
	[Luong] [float] NULL,
	[Ngaybatdau] [date] NULL,
	[Ngayketthuc] [date] NULL,
	[NhanvienId] [int] NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadon](
	[Id] [int] NOT NULL,
	[KhachhangId] [int] NULL,
	[NhanvienId] [int] NULL,
	[TrangthaihoadonId] [int] NULL,
	[Tongtien] [float] NULL,
	[Ngaylap] [date] NULL,
 CONSTRAINT [PK_Hoadon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Hoadon] ([Id], [KhachhangId], [NhanvienId], [TrangthaihoadonId], [Tongtien], [Ngaylap]) VALUES (1, 2, NULL, 1, 4000000, CAST(0x03380B00 AS Date))
INSERT [dbo].[Hoadon] ([Id], [KhachhangId], [NhanvienId], [TrangthaihoadonId], [Tongtien], [Ngaylap]) VALUES (2, 1, NULL, 1, 24500000, CAST(0x03380B00 AS Date))
/****** Object:  Table [dbo].[Chitietxuat]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietxuat](
	[Id] [int] NOT NULL,
	[XuathangId] [int] NULL,
	[SanphamId] [int] NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_Chitietxuat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chitietnhaphang]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietnhaphang](
	[Id] [int] NOT NULL,
	[NhaphangId] [int] NULL,
	[SanphamId] [int] NULL,
	[Soluong] [int] NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK_Chitietnhaphang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chitietkho]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietkho](
	[Id] [int] NOT NULL,
	[KhoId] [int] NULL,
	[SanphamId] [int] NULL,
	[Soluong] [int] NULL,
	[Ngay] [datetime] NULL,
 CONSTRAINT [PK_Chitietkho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (1, 1, 1, 10, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (2, 1, 2, 5, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (3, 1, 3, 9, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (4, 1, 4, 20, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (5, 1, 5, 10, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (6, 1, 6, 5, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (7, 1, 7, 30, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (8, 1, 8, 15, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (9, 1, 9, 22, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (10, 1, 10, 13, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (11, 1, 11, 18, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (12, 1, 12, 20, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (13, 1, 13, 9, CAST(0x0000A28700000000 AS DateTime))
INSERT [dbo].[Chitietkho] ([Id], [KhoId], [SanphamId], [Soluong], [Ngay]) VALUES (14, 1, 14, 20, CAST(0x0000A28700000000 AS DateTime))
/****** Object:  Table [dbo].[Chitiethoadon]    Script Date: 01/03/2014 21:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitiethoadon](
	[Id] [int] NOT NULL,
	[SanphamId] [int] NULL,
	[HoadonId] [int] NULL,
	[Soluong] [int] NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK_Chitiethoadon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Chitiethoadon] ([Id], [SanphamId], [HoadonId], [Soluong], [Gia]) VALUES (1, 1, 1, 2, 1500000)
INSERT [dbo].[Chitiethoadon] ([Id], [SanphamId], [HoadonId], [Soluong], [Gia]) VALUES (2, 4, 1, 1, 1000000)
INSERT [dbo].[Chitiethoadon] ([Id], [SanphamId], [HoadonId], [Soluong], [Gia]) VALUES (3, 1, 2, 3, 1500000)
INSERT [dbo].[Chitiethoadon] ([Id], [SanphamId], [HoadonId], [Soluong], [Gia]) VALUES (4, 13, 2, 2, 7000000)
INSERT [dbo].[Chitiethoadon] ([Id], [SanphamId], [HoadonId], [Soluong], [Gia]) VALUES (5, 10, 2, 1, 6000000)
/****** Object:  ForeignKey [FK_Chitiethoadon_Hoadon]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitiethoadon]  WITH CHECK ADD  CONSTRAINT [FK_Chitiethoadon_Hoadon] FOREIGN KEY([HoadonId])
REFERENCES [dbo].[Hoadon] ([Id])
GO
ALTER TABLE [dbo].[Chitiethoadon] CHECK CONSTRAINT [FK_Chitiethoadon_Hoadon]
GO
/****** Object:  ForeignKey [FK_Chitiethoadon_Sanpham]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitiethoadon]  WITH CHECK ADD  CONSTRAINT [FK_Chitiethoadon_Sanpham] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[Sanpham] ([Id])
GO
ALTER TABLE [dbo].[Chitiethoadon] CHECK CONSTRAINT [FK_Chitiethoadon_Sanpham]
GO
/****** Object:  ForeignKey [FK_Chitietkho_Kho]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitietkho]  WITH CHECK ADD  CONSTRAINT [FK_Chitietkho_Kho] FOREIGN KEY([KhoId])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[Chitietkho] CHECK CONSTRAINT [FK_Chitietkho_Kho]
GO
/****** Object:  ForeignKey [FK_Chitietkho_Sanpham]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitietkho]  WITH CHECK ADD  CONSTRAINT [FK_Chitietkho_Sanpham] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[Sanpham] ([Id])
GO
ALTER TABLE [dbo].[Chitietkho] CHECK CONSTRAINT [FK_Chitietkho_Sanpham]
GO
/****** Object:  ForeignKey [FK_Chitietnhaphang_Nhaphang]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitietnhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietnhaphang_Nhaphang] FOREIGN KEY([NhaphangId])
REFERENCES [dbo].[Nhaphang] ([Id])
GO
ALTER TABLE [dbo].[Chitietnhaphang] CHECK CONSTRAINT [FK_Chitietnhaphang_Nhaphang]
GO
/****** Object:  ForeignKey [FK_Chitietnhaphang_Sanpham]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitietnhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietnhaphang_Sanpham] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[Sanpham] ([Id])
GO
ALTER TABLE [dbo].[Chitietnhaphang] CHECK CONSTRAINT [FK_Chitietnhaphang_Sanpham]
GO
/****** Object:  ForeignKey [FK_Chitietxuat_Sanpham]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitietxuat]  WITH CHECK ADD  CONSTRAINT [FK_Chitietxuat_Sanpham] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[Sanpham] ([Id])
GO
ALTER TABLE [dbo].[Chitietxuat] CHECK CONSTRAINT [FK_Chitietxuat_Sanpham]
GO
/****** Object:  ForeignKey [FK_Chitietxuat_Xuathang]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Chitietxuat]  WITH CHECK ADD  CONSTRAINT [FK_Chitietxuat_Xuathang] FOREIGN KEY([XuathangId])
REFERENCES [dbo].[Xuathang] ([Id])
GO
ALTER TABLE [dbo].[Chitietxuat] CHECK CONSTRAINT [FK_Chitietxuat_Xuathang]
GO
/****** Object:  ForeignKey [FK_Hoadon_Khachhang]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Khachhang] FOREIGN KEY([KhachhangId])
REFERENCES [dbo].[Khachhang] ([Id])
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Khachhang]
GO
/****** Object:  ForeignKey [FK_Hoadon_Nhanvien]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Nhanvien] FOREIGN KEY([NhanvienId])
REFERENCES [dbo].[Nhanvien] ([Id])
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Nhanvien]
GO
/****** Object:  ForeignKey [FK_Hoadon_Trangthaihoadon]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Trangthaihoadon] FOREIGN KEY([TrangthaihoadonId])
REFERENCES [dbo].[Trangthaihoadon] ([Id])
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Trangthaihoadon]
GO
/****** Object:  ForeignKey [FK_Khachhang_Loaikhachhang]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Khachhang]  WITH CHECK ADD  CONSTRAINT [FK_Khachhang_Loaikhachhang] FOREIGN KEY([LoaikhachhangId])
REFERENCES [dbo].[Loaikhachhang] ([Id])
GO
ALTER TABLE [dbo].[Khachhang] CHECK CONSTRAINT [FK_Khachhang_Loaikhachhang]
GO
/****** Object:  ForeignKey [FK_Loaisanpham_Nhomsanpham]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Loaisanpham]  WITH CHECK ADD  CONSTRAINT [FK_Loaisanpham_Nhomsanpham] FOREIGN KEY([NhomspId])
REFERENCES [dbo].[Nhomsanpham] ([Id])
GO
ALTER TABLE [dbo].[Loaisanpham] CHECK CONSTRAINT [FK_Loaisanpham_Nhomsanpham]
GO
/****** Object:  ForeignKey [FK_Luong_Nhanvien]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Luong]  WITH CHECK ADD  CONSTRAINT [FK_Luong_Nhanvien] FOREIGN KEY([NhanvienId])
REFERENCES [dbo].[Nhanvien] ([Id])
GO
ALTER TABLE [dbo].[Luong] CHECK CONSTRAINT [FK_Luong_Nhanvien]
GO
/****** Object:  ForeignKey [FK_Nhanvien_Loainhanvien]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Loainhanvien] FOREIGN KEY([LoainhanvienId])
REFERENCES [dbo].[Loainhanvien] ([Id])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Loainhanvien]
GO
/****** Object:  ForeignKey [FK_Nhaphang_Kho]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Nhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Nhaphang_Kho] FOREIGN KEY([KhoId])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[Nhaphang] CHECK CONSTRAINT [FK_Nhaphang_Kho]
GO
/****** Object:  ForeignKey [FK_Nhaphang_Nhacungcap]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Nhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Nhaphang_Nhacungcap] FOREIGN KEY([NhacungcapId])
REFERENCES [dbo].[Nhacungcap] ([Id])
GO
ALTER TABLE [dbo].[Nhaphang] CHECK CONSTRAINT [FK_Nhaphang_Nhacungcap]
GO
/****** Object:  ForeignKey [FK_Nhaphang_Nhanvien]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Nhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Nhaphang_Nhanvien] FOREIGN KEY([NhanvienId])
REFERENCES [dbo].[Nhanvien] ([Id])
GO
ALTER TABLE [dbo].[Nhaphang] CHECK CONSTRAINT [FK_Nhaphang_Nhanvien]
GO
/****** Object:  ForeignKey [FK_Sanpham_Loaisanpham]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Loaisanpham] FOREIGN KEY([LoaisanphamId])
REFERENCES [dbo].[Loaisanpham] ([Id])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Loaisanpham]
GO
/****** Object:  ForeignKey [FK_Xuathang_Kho]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Xuathang]  WITH CHECK ADD  CONSTRAINT [FK_Xuathang_Kho] FOREIGN KEY([KhoId])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[Xuathang] CHECK CONSTRAINT [FK_Xuathang_Kho]
GO
/****** Object:  ForeignKey [FK_Xuathang_Nhanvien]    Script Date: 01/03/2014 21:26:24 ******/
ALTER TABLE [dbo].[Xuathang]  WITH CHECK ADD  CONSTRAINT [FK_Xuathang_Nhanvien] FOREIGN KEY([NhanvienId])
REFERENCES [dbo].[Nhanvien] ([Id])
GO
ALTER TABLE [dbo].[Xuathang] CHECK CONSTRAINT [FK_Xuathang_Nhanvien]
GO
