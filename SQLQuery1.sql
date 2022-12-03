use master
create database THHT
use THHT
create table DanhMuc
(
	MaDanhMuc int not null primary key,
	TenDanhMuc nvarchar(20) not null,
);
create table SanPham
(
	Ma int not null primary key,
	Ten nvarchar(50) not null,
	DonGia int not null,
	MaDanhMuc int FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc)
);

insert into DanhMuc(MaDanhMuc,TenDanhMuc) values (1,'Điện Tử');
insert into DanhMuc(MaDanhMuc,TenDanhMuc) values (2,'Gia Dụng');
insert into DanhMuc(MaDanhMuc,TenDanhMuc) values (3,'Nội Thất');

select *from DanhMuc

insert into SanPham(Ma,Ten,DonGia,MaDanhMuc) values ('1','Tủ Lạnh',1000000,1);
insert into SanPham(Ma,Ten,DonGia,MaDanhMuc) values ('2','Nồi Cơm',300000,2);
insert into SanPham(Ma,Ten,DonGia,MaDanhMuc) values ('3','Tivi',400000,1);

select *from SanPham