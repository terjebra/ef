# Add Model

Package:
Microsoft.EntityFrameworkCore.Design

Install tool:
dotnet tool install --global dotnet-ef

First migration (already created in Migration folder):
dotnet ef migrations add AddedCustomer


Apply chanages:
dotnet ef database update