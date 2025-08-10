create database QLSinhVien
go

use QLSinhVien
go

create table MonHoc(
	MaMH nchar(10) primary key,
	TenMH nvarchar(50) not null,
	SoTC integer not null
)

create table SinhVien(
	MaSV nchar(10) primary key,
	TenSV nvarchar(70) not null,
	Lop nchar(10) not null,
	MaMH nchar(10) not null,
	Diem float not null
)

insert into MonHoc values 
('MH1',N'Cơ sở dữ liệu',3),
('MH2',N'Lập trình Windows',3),
('MH3',N'Cơ sở dữ liệu',3)

insert into SinhVien values
('SV01', N'A', 'HTTT01','MH1', 7),
('SV02', N'B', 'HTTT02','MH2', 8.5),
('SV03', N'C', 'HTTT03','MH3', 9),
('SV04', N'D', 'CNTT01','MH3', 7),
('SV05', N'E', 'CNTT02','MH1', 2.5),
('SV06', N'F', 'CNTT03','MH1', 1)

select * from MonHoc
select * from SinhVien