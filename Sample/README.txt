-------------------------------------------- Documentation and Description -----------------------------------------------------------------

1. DTOs (Data Transafer Object) 
	digunakan untuk memfilter object dari database yang harus dikeluarkan atau object baru yang tidak ada didalam database

2. Interfaces 
	Interface adalah class yang mendefinisikan method yang akan diimplementasi oleh class yang menggunakan interface tersebut. 
	tidak ada proses didalamnya

3. Services
	Seluruh bisnis proses akan ditempatkan disini, dimana services akan mengimplementasi method2 didalam interfaces yg digunakan

4. Models
	Models adalah tempat seluruh object yang ada pada database kita. Ada satu class yg menjadi context yg mendefine seluruh object tsb.

5. Migrations 
	Migrations adalah perekam perubahan didatabase kita, jika ada penambahan atau perubahan pada object ikuti langkah yg dijelaskan dibawah.
	Migrations akan digenerate otomatis, jadi tidak perlu dibuat.

6. Repositories
	Disini kita menggunakan repository pattern yang termasuk salah satu design pattern dalam programming, untuk pengertian lebih lanjut pelajari tentang repository pattern.

---------------------------------- Step membuat database------------------------------
1. Buat class didalam models, Definiskan attribute2 nya.
2. buat kan context seperti pada contoh class SampleContext.cs
3. untuk membuat database setting terlebih dahulu database di ssms, tambahkan login kedatabase untuk connection string pada contoh appsettings.Development.json
4. kemudian definisikan pada startup.cs database kita seperti pada contoh di line ke 43 - 46
5. kemudian buka tools di visual studio kita pilih nuget package manager, 
	lalu pada command ketik dan eksekusi :  add-migration "deskripsi_migrasi"
	contoh : add-migration initial     atau    add-migration add_users_table
6. setelah selesai melakukan migrasi update database dengan menggunakan command :    update-database
7. ketika kita kembali ke ssms dan merefresh server akan terdapat database baru 
