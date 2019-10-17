SELECT 
	ClientName Client,
	DATEPART(MONTH, Date) Month,
	SUM(SUM(Amount)) OVER (Partition By ClientName ORDER BY ClientName, DATEPART(MONTH, Date))
FROM TableName Group By ClientName, DATEPART(MONTH, Date)