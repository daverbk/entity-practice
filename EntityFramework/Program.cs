using EF.services;
using Microsoft.EntityFrameworkCore;

var factory = new AdventureWorksContextFactory();

await using var context = factory.CreateDbContext();
{
    {
        var departmentsCount = context
            .Department
            .Count();

        Console.WriteLine($"Departments count: {departmentsCount}");

        var toolDesignDepartment = await context
            .Department
            .FirstAsync(dep => dep.Name == "Tool Design");

        Console.WriteLine($"Group name of design department: {toolDesignDepartment.GroupName}");
    }

    {
        var employeeDepartmentHistoryCount = context.EmployeeDepartmentHistory.Count();

        Console.WriteLine($"Employee department history records count: {employeeDepartmentHistoryCount}");

        var employeeDepartmentHistoryAfterFilterDate = await context
            .EmployeeDepartmentHistory
            .Where(hist => hist.StartDate.Year < 2010)
            .ToListAsync();

        Console.WriteLine(
            $"Employee department history records before 2010: {employeeDepartmentHistoryAfterFilterDate.Count}");
    }

    {
        var employeePayHistoryCount = context
            .EmployeePayHistory
            .Count();

        Console.WriteLine($"Employee pay history records count: {employeePayHistoryCount}");

        var maxRate = await context
            .EmployeePayHistory
            .MaxAsync(hist => hist.Rate);

        Console.WriteLine($"Max pay rate: {maxRate:C0}");
    }

    {
        var jobCandidatesCount = context
            .JobCandidate
            .Count();

        Console.WriteLine($"Job candidates count: {jobCandidatesCount}");

        var jobCandidateFromDec2013 = await context
            .JobCandidate
            .FirstAsync(candidate => candidate.ModifiedDate.Year == 2013 && candidate.ModifiedDate.Month == 12);
        
        Console.WriteLine($"Resume of job applicant from December 2013: {jobCandidateFromDec2013.Resume}");
    }

    {
        var shiftsCount = context
            .Shift
            .Count();

        Console.WriteLine($"Shifts count: {shiftsCount}");

        var nightShiftHours = await context
            .Shift
            .Where(shift => shift.Name.Contains("Night"))
            .Select(shift => new {shift.StartTime, shift.EndTime})
            .FirstAsync();

        Console.WriteLine($"Night shift starting hour: {nightShiftHours.StartTime} ending hour: {nightShiftHours.EndTime}");
    }

    {
        var addressesCount = context
            .Address
            .Count();

        Console.WriteLine($"Shifts count: {addressesCount}");

        var countOfAddressesInBothell = await context
            .Address
            .Where(address => address.City.Contains("Bothell"))
            .CountAsync();
        
        Console.WriteLine($"Addresses count in Bothell: {countOfAddressesInBothell}");
    }
    
    {
        var addressTypesCount = context
            .AddressType
            .Count();

        Console.WriteLine($"Shifts count: {addressTypesCount}");

        var primaryAddressType = await context
            .AddressType
            .FirstAsync(type => type.Name.Contains("Primary"));

        Console.WriteLine($"Primary address type id: {primaryAddressType.AddressTypeID}");
    }
    
    {
        var businessEntitiesCount = context
            .BusinessEntity
            .Count();

        Console.WriteLine($"Shifts count: {businessEntitiesCount}");

        var businessEntityByGuid = await context
            .BusinessEntity
            .FirstAsync(type => type.RowGuid.Equals(new Guid("0f3cc1d7-f484-4bde-b088-b11ef03e2f52")));

        Console.WriteLine($"Primary address type id: {businessEntityByGuid.BusinessEntityID}");
    }

    {
        
    }
}
