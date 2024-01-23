# 實作功能
於開發環境中架設可用來說明 API 規格的說明文件

## 驗收方式
1. 於 web browser 上輸入 ip:port/doc 後可出現 swagger 文件
2. 文件內容須包含 header/body/param/response
3. 做一個簡易的CRUD功能(新增/刪除/修改/查詢)
4. 撰寫單元測試功能(UnitTest)，測試CRUD功能是否如預期  
[.NET Core 和 .NET Standard 的單元測試最佳做法](https://learn.microsoft.com/zh-tw/dotnet/core/testing/unit-testing-best-practices)  
PS.需寫一個Service，透過Dependency Injection注入Service完成CRUD的功能  
尚未有資料庫，Service使用Singleton的方式注入Service

## 附註
補充說明