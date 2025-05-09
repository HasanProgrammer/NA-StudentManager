این پروژه برای مدیریت ساده کاربران پیاده سازی شده است ( پروژه اصلی در فولدر Onion -> sample می باشد )

در این پروژه از معماری Domain Centric ( مشخصا معماری Clean ) استفاده شده است و بیشتر بیزینس ها مانند بیزینس رول های اعتبارسنجی داخل لایه Doamin ( Core -> Student.Core.Domain ) پیاده سازی شده با استفاده از ValueObject ها

در این پروژه زیرساخت لاجیک های Command و Query جدا می باشد ولی برای این پروژه، گزارش ها و کامند ها در قسمت Command پیاده سازی شده ، برای جلوگیری از پیچیده شدن و ...

مدیریت بیزینس های حول دامنه ( Business Orchestration ) در لایه Student.Core.ApplicationService می باشد

برای مدیریت لایه Domain و مشخصا Entity ها از الگوی Rich Domain Model استفاده شده و خیلی به رویکرد DDD توجه نشده است ( برای جلوگیری از پیچیده شدن ساختار )

موجودیت های این پروژه ( Student و Category ) از ساختار ValueObject ها برای مدیریت بیزینس رول ها استفاده می کنن ( اعتبارسنجی )

برای مفهوم گروه بندی از موجودیتی به اسم Category استفاده شده است که رابطه آن با موجودیت Student ، ( یک به چند ) می باشد

کلاس های مربوط به Command Dto و Query Dto در قسمت Core -> Student.Core.RequestResponse قرار گرفته اند

به ازای Action های مختلف روی Entity ها Event های مختلفی صدا زده میشود که از همین رخداد ها می توان به عنوان LogHistory استفاده کرد

در این ساختار هر موجودیتی ( Command ) ها ، از یکسری فیلد ( Audit Field ) به عنوان Audit Log استفاده می کند که برای منظور Activity Log میتوان روی آنها حساب کرد که البته Full Audit نمی باشند ( مثلا Role و ... را نگه نمیدارند ، برای این منظور خاص میتوان از Event های ثبت شده در دیتابیس استفاده کرد ) | این Event ها در Schema ایی با نام ( zamin ) و با نام جدولی تحت عنوان OutBoxEventItems در دسترس می باشد

مدیریت دیتابیس ( Repository Implementation ) و ( Entity Config ) ها همگی در لایه Infra -> Data -> Student.Infra.Data.Sql.Commands مدیریت شده اند

در نهایت خروجی API ها در لایه Student.Endpoints.API و در قسمت EndPoints می باشد
