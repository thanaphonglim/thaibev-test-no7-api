# amass-product-test-api

.Net Core Web API สำหรับ จัดการสินค้า เนื่องจาก โจทย์ conflict กับตัวอย่างในรูปเลยอิงโจทย์เป็นหลัก

## Feature
### Product
- [CREATE] สร้างสินค้า โดยรหัสสินค้าจะเป็นได้ทั้งตัวเลข และตัวอักษรภาษาอังกฤษพิมพ์ใหญ่เท่านั้น มีความยาว 30 หลัก ตัวอย่าง => (7E9L2-IYAS0-4NYA1-ZBIDT-PE8AN-15IM4)
- [DELETE] ลบสินค้า
- [GET] เรียกดูสินค้า
- [GET] ค้นหาสินค้าด้วยรหัสสินค้า

## Database
- เก็บข้อมูลในรูปแบบ In-Memmory โดยใช้ SQLite in-memory database ทำให้ ฐานข้อมูลจะถูก reset เมื่อมีการปิด applicaton

## Architecture 
### โปรเจคนี้พัฒนาในรูปแบบ Minimal-API โดยใช้โครงสร้างแบบ Clean Architecture โดยมีรายละเอียดในแต่ละ Layer ดังนี้
- Domain: business entities และ core logic
- Application: use cases/service และ interfaces
- Infrastructure: database และ repository 
- Api: HTTP endpoints/Controller

## API Endpoints
- POST
 /api/products
- GET
/api/products,
/api/products/search
- DELETE
/api/products/{id}

## Swagger
- https://domain:port/swagger

## Run
- dotnet run

