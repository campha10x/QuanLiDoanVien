USE [QuanLiDoanVien]
GO
/****** Object:  StoredProcedure [dbo].[sp_CanBoDoan_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CanBoDoan_Delete]
	@MaCB int
AS
BEGIN
	delete from tbl_CANBODOAN where MaCB=@MaCB 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CanBoDoan_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_CanBoDoan_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' * FROM [tbl_CANBODOAN]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_CanBoDoan_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CanBoDoan_Insert]
	@HoTen nvarchar(50),
	@GioiTinh nvarchar(50),
	@ChucVu nvarchar(50),
	@DiaChi nvarchar(50),
	@DienThoai varchar(50)
AS
BEGIN
	insert into tbl_CANBODOAN(HoTen,GioiTinh,ChucVu,DiaChi,DienThoai)
	values(@HoTen,@GioiTinh,@ChucVu,@DiaChi,@DienThoai)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CanBoDoan_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CanBoDoan_Update]
	@MaCB int,
	@HoTen nvarchar(50),
	@GioiTinh nvarchar(50),
	@ChucVu nvarchar(50),
	@DiaChi nvarchar(50),
	@DienThoai varchar(50)
AS
BEGIN
	update tbl_CANBODOAN set HoTen = @HoTen,GioiTinh=@GioiTinh,
	ChucVu=@ChucVu,DiaChi=@DiaChi,DienThoai=@DienThoai
	where MaCB = @MaCB
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiDoan_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChiDoan_Delete]
	@MaChiDoan int
AS
BEGIN
	delete from tbl_ChiDoan where MaChiDoan=@MaChiDoan 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiDoan_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[sp_ChiDoan_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' * FROM [tbl_ChiDoan]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiDoan_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChiDoan_Insert]
	@TenChiDoan varchar(50),
	@MaKhoaHoc int
AS
BEGIN
	insert into dbo.tbl_ChiDoan(TenChiDoan,MaKhoaHoc) values(@TenChiDoan,@MaKhoaHoc)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiDoan_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChiDoan_Update]
	@MaChiDoan int,
	@TenChiDoan varchar(50),
	@MaKhoaHoc int
AS
BEGIN
	update tbl_ChiDoan set   TenChiDoan = @TenChiDoan,MaKhoaHoc=@MaKhoaHoc
	where MaChiDoan = @MaChiDoan
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanToc_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DanToc_Delete]
	@MaDT int
AS
BEGIN
	delete from tbl_DanToc where MaDT=@MaDT 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanToc_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_DanToc_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' * FROM [tbl_DanToc]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_DanToc_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DanToc_Insert]
	@TenDT nvarchar(50)
AS
BEGIN
	insert into dbo.tbl_DanToc(TenDT) values(@TenDT)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DanToc_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DanToc_Update]
	@MaDT int,
	@TenDT nvarchar(50)
AS
BEGIN
	update tbl_DanToc set   TenDT = @TenDT
	where MaDT = @MaDT
END

GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongDoan_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoatDongDoan_Delete]
	@Id int
AS
BEGIN
	delete from tbl_THONGTINHOATDONGDOAN where Id=@Id 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongDoan_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_HoatDongDoan_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' Id,CONVERT(VARCHAR,ThoiGian,103) as ThoiGian,MaCB,TenHoatDong,KetQua FROM [tbl_THONGTINHOATDONGDOAN]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongDoan_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoatDongDoan_Insert]
	@TenHoatDong nvarchar(50),
	@ThoiGian date,
	@MaCB int,
	@KetQua nvarchar(50)
AS
BEGIN
	insert into tbl_THONGTINHOATDONGDOAN(TenHoatDong,ThoiGian,MaCB,KetQua)
	values(@TenHoatDong,@ThoiGian,@MaCB,@KetQua)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongDoan_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoatDongDoan_Update]
	@Id int,
	@TenHoatDong nvarchar(50),
	@ThoiGian date,
	@MaCB int,
	@KetQua nvarchar(50)
AS
BEGIN
	update tbl_THONGTINHOATDONGDOAN set 
	TenHoatDong=@TenHoatDong,ThoiGian=@ThoiGian,MaCB=@MaCB,KetQua=@KetQua
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KhoaHoc_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhoaHoc_Delete]
	@MaKhoaHoc int
AS
BEGIN
	delete from tbl_KhoaHoc where MaKhoaHoc=@MaKhoaHoc 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KhoaHoc_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[sp_KhoaHoc_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' * FROM [tbl_KhoaHoc]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_KhoaHoc_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhoaHoc_Insert]
	@ThoiGianDaoTao varchar(50)
AS
BEGIN
	insert into dbo.tbl_KhoaHoc(ThoiGianDaoTao) values(@ThoiGianDaoTao)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KhoaHoc_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhoaHoc_Update]
	@MaKhoaHoc int,
	@ThoiGianDaoTao varchar(50)
AS
BEGIN
	update tbl_KhoaHoc set   ThoiGianDaoTao = @ThoiGianDaoTao
	where MaKhoaHoc = @MaKhoaHoc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_NguoiDung_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_NguoiDung_Update]
	@Id int,
	@TenDangNhap varchar(50),
	@IdQuyen int,
	@MatKhau varchar(50),
	@MaCB int
AS
BEGIN
	update tbl_NGUOIDUNG set TenDangNhap = @TenDangNhap,IdQuyen=@IdQuyen
	,MatKhau=@MatKhau,MaCB=@MaCB
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PhiDoan_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhiDoan_Delete]
	@ID int
AS
BEGIN
	delete from tbl_PhiDoan where ID=@ID 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PhiDoan_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_PhiDoan_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' * FROM [tbl_PhiDoan]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_PhiDoan_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhiDoan_Insert]
	@Nam int,
	@MaSV int,
	@PhiDoan decimal(18, 0)
AS
BEGIN
	insert into tbl_PhiDoan(Nam,MaSV,PhiDoan)
	values(@Nam,@MaSV,@PhiDoan)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PhiDoan_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhiDoan_Update]
	@ID int,
	@Nam int,
	@MaSV int,
	@PhiDoan decimal(18, 0)
AS
BEGIN
	update tbl_PhiDoan set 
	Nam=@Nam,MaSV=@MaSV,PhiDoan=@PhiDoan
	where ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SinhVien_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SinhVien_Delete]
	@MaSV int
AS
BEGIN
	delete from tbl_SINHVIEN where MaSV=@MaSV 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SinhVien_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SinhVien_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + N' MaSV,HoTenSV,CONVERT(VARCHAR,NgaySinh,103) as
	 NgaySinh,DiaChi,DienThoai,TinhTrang,MaDT,MaChiDoan,CONVERT(VARCHAR,NgayVaoDoan,103) as NgayVaoDoan, CASE WHEN TinhTrangNopPhi=1 THEN N''Đã nộp'' ELSE N''Chưa nộp'' END AS TinhTrangNopPhi FROM [tbl_SINHVIEN]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)

GO
/****** Object:  StoredProcedure [dbo].[sp_SinhVien_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SinhVien_Insert]
	@HoTenSV nvarchar(50),
	@NgaySinh date,
	@DiaChi nvarchar(50),
	@DienThoai varchar(50),
	@MaChiDoan int,
	@NgayVaoDoan date,
	@TinhTrang nvarchar(50),
	@MaDT int
AS
BEGIN
	insert into dbo.tbl_SINHVIEN(HoTenSV,NgaySinh,DiaChi,DienThoai,MaChiDoan
	,NgayVaoDoan,TinhTrang,MaDT) 
	values(@HoTenSV,@NgaySinh,@DiaChi,@DienThoai,@MaChiDoan
	,@NgayVaoDoan,@TinhTrang,@MaDT)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SinhVien_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SinhVien_Update]
	@MaSV int,
	@HoTenSV nvarchar(50),
	@NgaySinh date,
	@DiaChi nvarchar(50),
	@DienThoai varchar(50),
	@MaChiDoan int,
	@NgayVaoDoan date,
	@TinhTrang nvarchar(50),
	@MaDT int
AS
BEGIN
	update tbl_SINHVIEN set   HoTenSV = @HoTenSV,NgaySinh=@NgaySinh,DiaChi=@DiaChi,
	DienThoai=@DienThoai,MaChiDoan=@MaChiDoan,NgayVaoDoan=@NgayVaoDoan
	,TinhTrang=@TinhTrang,MaDT=@MaDT
	where MaSV = @MaSV
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_NGUOIDUNG_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_tbl_NGUOIDUNG_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' *  FROM [tbl_NGUOIDUNG]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)

GO
/****** Object:  StoredProcedure [dbo].[sp_XepLoaiSV_Delete]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XepLoaiSV_Delete]
	@Id int
AS
BEGIN
	delete from tbl_XepLoaiSV where Id=@Id 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_XepLoaiSV_getByTop]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[sp_XepLoaiSV_getByTop]
@Top	nvarchar(10),
@Where	nvarchar(MAX),
@Order	nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop = '(' + @Top + ')'
	if len(@Top) = 0 
		BEGIN
			Select @strTop = '100 percent'
		END
	Select @SQL = 'SELECT top ' + @strTop + ' * FROM [tbl_XepLoaiSV]'
	if len(@Where) >0 
		BEGIN
			Select @SQL = @SQL + ' Where ' + @Where
		END
	if len(@Order) >0
		BEGIN
			Select @SQL = @SQL + ' Order by ' + @Order
		END
	EXEC (@SQL)
GO
/****** Object:  StoredProcedure [dbo].[sp_XepLoaiSV_Insert]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XepLoaiSV_Insert]
	@Nam int,
	@XepLoai nvarchar(50),
	@MaSV int
AS
BEGIN
	insert into dbo.tbl_XepLoaiSV(Nam,XepLoai,MaSV) 
	values(@Nam,@XepLoai,@MaSV)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_XepLoaiSV_Update]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XepLoaiSV_Update]
	@Id int,
	@Nam int,
	@XepLoai nvarchar(50),
	@MaSV int
AS
BEGIN
	update tbl_XepLoaiSV set   Nam = @Nam,XepLoai=@XepLoai,MaSV=@MaSV
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_XetDangVien]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[sp_XetDangVien]
@NamBd	int,
@NamKT	int
AS	
SELECT  DISTINCT(tbl_XepLoaiSV.MaSV) FROM tbl_XepLoaiSV
inner join (SELECT COUNT(*) as soluong,MaSV FROM tbl_XepLoaiSV where XepLoai=N'Xuất sắc' and Nam between '2012' and '2017'
		group by MaSV) as SoLuongXepLoai on tbl_XepLoaiSV.MaSV=SoLuongXepLoai.MaSV
inner join tbl_SINHVIEN on tbl_SINHVIEN.MaSV=tbl_XepLoaiSV.MaSV
where SoLuongXepLoai.soluong>=3 and tbl_SINHVIEN.TinhTrang=N'Đoàn viên'

GO
/****** Object:  Table [dbo].[tbl_CANBODOAN]    Script Date: 5/28/2017 11:44:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_CANBODOAN](
	[MaCB] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[ChucVu] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_CANBODOAN] PRIMARY KEY CLUSTERED 
(
	[MaCB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ChiDoan]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ChiDoan](
	[MaChiDoan] [int] IDENTITY(1,1) NOT NULL,
	[TenChiDoan] [varchar](50) NULL,
	[MaKhoaHoc] [int] NULL,
 CONSTRAINT [PK_tbl_ChiDoan] PRIMARY KEY CLUSTERED 
(
	[MaChiDoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_DanToc]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DanToc](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[TenDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_DanToc] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_KhoaHoc]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_KhoaHoc](
	[MaKhoaHoc] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianDaoTao] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_KhoaHoc] PRIMARY KEY CLUSTERED 
(
	[MaKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_NGUOIDUNG]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_NGUOIDUNG](
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[IdQuyen] [int] NULL,
	[MaCB] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_NhomNguoiDung]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_NhomNguoiDung](
	[ID] [int] NOT NULL,
	[TenMenu] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Order] [int] NULL,
	[Level] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_tbl_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_PhiDoan]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PhiDoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nam] [int] NOT NULL,
	[MaSV] [int] NULL,
	[PhiDoan] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_PhiDoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Quyen]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Quyen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Them] [bit] NULL,
	[Sua] [bit] NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_tbl_Quyen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SINHVIEN]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SINHVIEN](
	[MaSV] [int] IDENTITY(1,1) NOT NULL,
	[HoTenSV] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[MaDT] [int] NULL,
	[MaChiDoan] [int] NULL,
	[NgayVaoDoan] [date] NULL,
	[TinhTrangNopPhi] [bit] NULL,
 CONSTRAINT [PK_tbl_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SODOAN]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SODOAN](
	[SoSD] [int] IDENTITY(1,1) NOT NULL,
	[ThongTin] [nvarchar](max) NULL,
	[NhanXet] [nvarchar](max) NULL,
	[MaSV] [int] NULL,
 CONSTRAINT [PK_tbl_SODOAN] PRIMARY KEY CLUSTERED 
(
	[SoSD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_THONGTINCHUYENSINHHOATDOAN]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_THONGTINCHUYENSINHHOATDOAN](
	[NgayChuyen] [date] NULL,
	[NoiChuyenDen] [nvarchar](50) NULL,
	[MaSV] [int] NULL,
	[MaCB] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_THONGTINHOATDONGDOAN]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_THONGTINHOATDONGDOAN](
	[TenHoatDong] [nvarchar](50) NULL,
	[ThoiGian] [date] NULL,
	[MaCB] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KetQua] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_THONGTINHOATDONGDOAN] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_THONGTINNOPSODOAN]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_THONGTINNOPSODOAN](
	[NgayNop] [date] NULL,
	[SoSD] [int] NULL,
	[MaSV] [int] NULL,
	[MaCB] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_XepLoaiSV]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_XepLoaiSV](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nam] [int] NULL,
	[XepLoai] [nvarchar](50) NULL,
	[MaSV] [int] NULL,
 CONSTRAINT [PK_XepLoaiSV] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_CANBODOAN] ON 

INSERT [dbo].[tbl_CANBODOAN] ([MaCB], [HoTen], [GioiTinh], [ChucVu], [DiaChi], [DienThoai]) VALUES (1, N'Phạm Xuân Duy', 1, N'1', N'1', N'1')
SET IDENTITY_INSERT [dbo].[tbl_CANBODOAN] OFF
SET IDENTITY_INSERT [dbo].[tbl_ChiDoan] ON 

INSERT [dbo].[tbl_ChiDoan] ([MaChiDoan], [TenChiDoan], [MaKhoaHoc]) VALUES (4, N'D9CNPM', 3)
INSERT [dbo].[tbl_ChiDoan] ([MaChiDoan], [TenChiDoan], [MaKhoaHoc]) VALUES (5, N'D9TMDT', 3)
INSERT [dbo].[tbl_ChiDoan] ([MaChiDoan], [TenChiDoan], [MaKhoaHoc]) VALUES (6, N'D9-QTKD', 3)
SET IDENTITY_INSERT [dbo].[tbl_ChiDoan] OFF
SET IDENTITY_INSERT [dbo].[tbl_DanToc] ON 

INSERT [dbo].[tbl_DanToc] ([MaDT], [TenDT]) VALUES (1, N'Kinh')
INSERT [dbo].[tbl_DanToc] ([MaDT], [TenDT]) VALUES (2, N'Mường')
INSERT [dbo].[tbl_DanToc] ([MaDT], [TenDT]) VALUES (4, N'Thái')
INSERT [dbo].[tbl_DanToc] ([MaDT], [TenDT]) VALUES (5, N'Tày')
INSERT [dbo].[tbl_DanToc] ([MaDT], [TenDT]) VALUES (6, N'Sắn rừu1')
SET IDENTITY_INSERT [dbo].[tbl_DanToc] OFF
SET IDENTITY_INSERT [dbo].[tbl_KhoaHoc] ON 

INSERT [dbo].[tbl_KhoaHoc] ([MaKhoaHoc], [ThoiGianDaoTao]) VALUES (3, N'2014-2017')
INSERT [dbo].[tbl_KhoaHoc] ([MaKhoaHoc], [ThoiGianDaoTao]) VALUES (4, N'2015-1019')
SET IDENTITY_INSERT [dbo].[tbl_KhoaHoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_NGUOIDUNG] ON 

INSERT [dbo].[tbl_NGUOIDUNG] ([TenDangNhap], [MatKhau], [IdQuyen], [MaCB], [Id]) VALUES (N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_NGUOIDUNG] OFF
SET IDENTITY_INSERT [dbo].[tbl_PhiDoan] ON 

INSERT [dbo].[tbl_PhiDoan] ([ID], [Nam], [MaSV], [PhiDoan]) VALUES (1, 2015, 9, CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[tbl_PhiDoan] ([ID], [Nam], [MaSV], [PhiDoan]) VALUES (4, 2001, 12, CAST(10001 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tbl_PhiDoan] OFF
SET IDENTITY_INSERT [dbo].[tbl_Quyen] ON 

INSERT [dbo].[tbl_Quyen] ([Id], [Them], [Sua], [Xoa]) VALUES (1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Quyen] OFF
SET IDENTITY_INSERT [dbo].[tbl_SINHVIEN] ON 

INSERT [dbo].[tbl_SINHVIEN] ([MaSV], [HoTenSV], [NgaySinh], [DiaChi], [DienThoai], [TinhTrang], [MaDT], [MaChiDoan], [NgayVaoDoan], [TinhTrangNopPhi]) VALUES (9, N'Phạm Xuân Duy', CAST(0x191F0B00 AS Date), N'Quảng ninh', N'1', N'Đoàn viên', 1, 4, CAST(0xB53C0B00 AS Date), 1)
INSERT [dbo].[tbl_SINHVIEN] ([MaSV], [HoTenSV], [NgaySinh], [DiaChi], [DienThoai], [TinhTrang], [MaDT], [MaChiDoan], [NgayVaoDoan], [TinhTrangNopPhi]) VALUES (11, N'Nguyễn Văn Hiếu', CAST(0x0F1D0B00 AS Date), N'Hà Nội', N'1', N'Đoàn viên', 1, 4, CAST(0x733C0B00 AS Date), 0)
INSERT [dbo].[tbl_SINHVIEN] ([MaSV], [HoTenSV], [NgaySinh], [DiaChi], [DienThoai], [TinhTrang], [MaDT], [MaChiDoan], [NgayVaoDoan], [TinhTrangNopPhi]) VALUES (12, N'1', CAST(0xCB3C0B00 AS Date), N'1', N'1', N'Đoàn viên', 1, 4, CAST(0xC43C0B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[tbl_SINHVIEN] OFF
SET IDENTITY_INSERT [dbo].[tbl_THONGTINHOATDONGDOAN] ON 

INSERT [dbo].[tbl_THONGTINHOATDONGDOAN] ([TenHoatDong], [ThoiGian], [MaCB], [Id], [KetQua]) VALUES (N'Tiếp sức mùa thi', CAST(0xA53C0B00 AS Date), 1, 1, N'Tot')
SET IDENTITY_INSERT [dbo].[tbl_THONGTINHOATDONGDOAN] OFF
SET IDENTITY_INSERT [dbo].[tbl_XepLoaiSV] ON 

INSERT [dbo].[tbl_XepLoaiSV] ([Id], [Nam], [XepLoai], [MaSV]) VALUES (1, 2016, N'Xuất sắc', 9)
INSERT [dbo].[tbl_XepLoaiSV] ([Id], [Nam], [XepLoai], [MaSV]) VALUES (2, 2014, N'Xuất sắc', 11)
INSERT [dbo].[tbl_XepLoaiSV] ([Id], [Nam], [XepLoai], [MaSV]) VALUES (5, 2016, N'Tốt', 11)
INSERT [dbo].[tbl_XepLoaiSV] ([Id], [Nam], [XepLoai], [MaSV]) VALUES (6, 2015, N'Xuất sắc', 9)
INSERT [dbo].[tbl_XepLoaiSV] ([Id], [Nam], [XepLoai], [MaSV]) VALUES (7, 2014, N'Xuất sắc', 9)
INSERT [dbo].[tbl_XepLoaiSV] ([Id], [Nam], [XepLoai], [MaSV]) VALUES (8, 2015, N'Xuất sắc', 11)
SET IDENTITY_INSERT [dbo].[tbl_XepLoaiSV] OFF
ALTER TABLE [dbo].[tbl_ChiDoan]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ChiDoan_tbl_KhoaHoc] FOREIGN KEY([MaKhoaHoc])
REFERENCES [dbo].[tbl_KhoaHoc] ([MaKhoaHoc])
GO
ALTER TABLE [dbo].[tbl_ChiDoan] CHECK CONSTRAINT [FK_tbl_ChiDoan_tbl_KhoaHoc]
GO
ALTER TABLE [dbo].[tbl_NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_tbl_NGUOIDUNG_tbl_CANBODOAN] FOREIGN KEY([MaCB])
REFERENCES [dbo].[tbl_CANBODOAN] ([MaCB])
GO
ALTER TABLE [dbo].[tbl_NGUOIDUNG] CHECK CONSTRAINT [FK_tbl_NGUOIDUNG_tbl_CANBODOAN]
GO
ALTER TABLE [dbo].[tbl_PhiDoan]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PhiDoan_tbl_SINHVIEN] FOREIGN KEY([MaSV])
REFERENCES [dbo].[tbl_SINHVIEN] ([MaSV])
GO
ALTER TABLE [dbo].[tbl_PhiDoan] CHECK CONSTRAINT [FK_tbl_PhiDoan_tbl_SINHVIEN]
GO
ALTER TABLE [dbo].[tbl_SINHVIEN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SINHVIEN_tbl_ChiDoan1] FOREIGN KEY([MaChiDoan])
REFERENCES [dbo].[tbl_ChiDoan] ([MaChiDoan])
GO
ALTER TABLE [dbo].[tbl_SINHVIEN] CHECK CONSTRAINT [FK_tbl_SINHVIEN_tbl_ChiDoan1]
GO
ALTER TABLE [dbo].[tbl_SINHVIEN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SINHVIEN_tbl_DanToc] FOREIGN KEY([MaDT])
REFERENCES [dbo].[tbl_DanToc] ([MaDT])
GO
ALTER TABLE [dbo].[tbl_SINHVIEN] CHECK CONSTRAINT [FK_tbl_SINHVIEN_tbl_DanToc]
GO
ALTER TABLE [dbo].[tbl_THONGTINCHUYENSINHHOATDOAN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_THONGTINCHUYENSINHHOATDOAN_tbl_CANBODOAN] FOREIGN KEY([MaCB])
REFERENCES [dbo].[tbl_CANBODOAN] ([MaCB])
GO
ALTER TABLE [dbo].[tbl_THONGTINCHUYENSINHHOATDOAN] CHECK CONSTRAINT [FK_tbl_THONGTINCHUYENSINHHOATDOAN_tbl_CANBODOAN]
GO
ALTER TABLE [dbo].[tbl_THONGTINCHUYENSINHHOATDOAN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_THONGTINCHUYENSINHHOATDOAN_tbl_SINHVIEN] FOREIGN KEY([MaSV])
REFERENCES [dbo].[tbl_SINHVIEN] ([MaSV])
GO
ALTER TABLE [dbo].[tbl_THONGTINCHUYENSINHHOATDOAN] CHECK CONSTRAINT [FK_tbl_THONGTINCHUYENSINHHOATDOAN_tbl_SINHVIEN]
GO
ALTER TABLE [dbo].[tbl_THONGTINHOATDONGDOAN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_THONGTINHOATDONGDOAN_tbl_CANBODOAN2] FOREIGN KEY([MaCB])
REFERENCES [dbo].[tbl_CANBODOAN] ([MaCB])
GO
ALTER TABLE [dbo].[tbl_THONGTINHOATDONGDOAN] CHECK CONSTRAINT [FK_tbl_THONGTINHOATDONGDOAN_tbl_CANBODOAN2]
GO
ALTER TABLE [dbo].[tbl_THONGTINNOPSODOAN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_THONGTINNOPSODOAN_tbl_CANBODOAN] FOREIGN KEY([MaCB])
REFERENCES [dbo].[tbl_CANBODOAN] ([MaCB])
GO
ALTER TABLE [dbo].[tbl_THONGTINNOPSODOAN] CHECK CONSTRAINT [FK_tbl_THONGTINNOPSODOAN_tbl_CANBODOAN]
GO
ALTER TABLE [dbo].[tbl_THONGTINNOPSODOAN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_THONGTINNOPSODOAN_tbl_SINHVIEN] FOREIGN KEY([MaSV])
REFERENCES [dbo].[tbl_SINHVIEN] ([MaSV])
GO
ALTER TABLE [dbo].[tbl_THONGTINNOPSODOAN] CHECK CONSTRAINT [FK_tbl_THONGTINNOPSODOAN_tbl_SINHVIEN]
GO
ALTER TABLE [dbo].[tbl_THONGTINNOPSODOAN]  WITH CHECK ADD  CONSTRAINT [FK_tbl_THONGTINNOPSODOAN_tbl_SODOAN] FOREIGN KEY([SoSD])
REFERENCES [dbo].[tbl_SODOAN] ([SoSD])
GO
ALTER TABLE [dbo].[tbl_THONGTINNOPSODOAN] CHECK CONSTRAINT [FK_tbl_THONGTINNOPSODOAN_tbl_SODOAN]
GO
ALTER TABLE [dbo].[tbl_XepLoaiSV]  WITH CHECK ADD  CONSTRAINT [FK_tbl_XepLoaiSV_tbl_SINHVIEN] FOREIGN KEY([MaSV])
REFERENCES [dbo].[tbl_SINHVIEN] ([MaSV])
GO
ALTER TABLE [dbo].[tbl_XepLoaiSV] CHECK CONSTRAINT [FK_tbl_XepLoaiSV_tbl_SINHVIEN]
GO
/****** Object:  Trigger [dbo].[tg_Delete_SV_TinhTrang]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE TRIGGER [dbo].[tg_Delete_SV_TinhTrang]
ON [dbo].[tbl_PhiDoan]
FOR DELETE
AS
 BEGIN
	DECLARE @MaSV_Del int
	SET @MaSV_Del=(SELECT MaSV from deleted)
	UPDATE tbl_SINHVIEN
	SET TinhTrangNopPhi='False'
	WHERE MaSV=@MaSV_Del
 END
GO
/****** Object:  Trigger [dbo].[tg_Insert_SV_TinhTrang]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_Insert_SV_TinhTrang]
ON [dbo].[tbl_PhiDoan]
FOR INSERT
AS
 BEGIN
	DECLARE @MaSV int
	SET @MaSV=(SELECT MaSV from inserted)
	UPDATE tbl_SINHVIEN
	SET TinhTrangNopPhi='True'
	WHERE MaSV=@MaSV
 END
GO
/****** Object:  Trigger [dbo].[tg_Update_SV_TinhTrang]    Script Date: 5/28/2017 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE TRIGGER [dbo].[tg_Update_SV_TinhTrang]
ON [dbo].[tbl_PhiDoan]
FOR UPDATE
AS
 BEGIN
	DECLARE @MaSV int,@MaSV_Del int
	SET @MaSV=(SELECT MaSV from inserted)
	SET @MaSV_Del=(SELECT MaSV from deleted)
	UPDATE tbl_SINHVIEN
	SET TinhTrangNopPhi='True'
	WHERE MaSV=@MaSV
	UPDATE tbl_SINHVIEN
	SET TinhTrangNopPhi='False'
	WHERE MaSV=@MaSV_Del
 END
GO
