ALTER PROCEDURE SpAddNewData
(
@EmpName VARCHAR(30),
@PhoneNumber BIGINT,
@Address  VARCHAR(100),
@Department VARCHAR(20),
@Gender VARCHAR(1),
@BasicPay FLOAT,
@Deduction FLOAT,
@TaxablePay FLOAT,
@TAX FLOAT,
@NetPay FLOAT,
@StartDate DATE,
@City VARCHAR(20),
@Country VARCHAR(20)
)

AS BEGIN 
INSERT INTO EmpPayRoll_Table(EmpName,PhoneNumber,Address ,Department, Gender,BasicPay ,Deduction ,TaxablePay ,TAX ,NetPay ,StartDate ,City ,Country)
VALUES (@EmpName, @PhoneNumber, @Address , @Department  ,@Gender,@BasicPay ,@Deduction ,@TaxablePay ,@TAX ,@NetPay ,@StartDate ,@City ,@Country )
END


