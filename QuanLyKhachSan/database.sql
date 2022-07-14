use master
go
create database QuanLyKhachSan
go
use QuanLyKhachSan
go
create table TaiKhoan(
	TenTK varchar(20) primary key,
	MatKhau varchar(20) not null,
	LoaiTK nvarchar(20)
)
go
create table NhanVien(
	Id int identity primary key,
	TenNV nvarchar(50) not null,
	NgaySinh varchar(50),
	DiaChi nvarchar(50),
	SDT char(10)
)
go
create table Phong(
	Id int identity(1000,1) primary key,
	LoaiPhong nvarchar(50),
	Gia int,
	TrangThai bit default 0
)
go
create table DichVu(
	Id int identity primary key,
	TenDV nvarchar(50) not null,
	Gia int
)
go
create table HoaDon(
	ID int identity primary key,
	TenKH nvarchar(50) not null,
	SoCC char(20),
	IdPhong int not null,
	NgayThue date,
	NgayTra date,
	TrangThai bit default 0
)
go
create table CTHoaDon(
	Id int identity primary key,
	IdHoaDon int not null,
	IdDichVu int not null,
	SoLuong int
)
select * from NhanVien