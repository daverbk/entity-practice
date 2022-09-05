using EF.services;
using Microsoft.EntityFrameworkCore;

var factory = new AdventureWorksContextFactory();

// Simple queries to the database tables ...

await using var context = factory.CreateDbContext();
{
    {
        var departmentsCount = await context
            .Department
            .CountAsync();

        Console.WriteLine($"Departments count: {departmentsCount}");

        var toolDesignDepartment = await context
            .Department
            .FirstAsync(dep => dep.Name == "Tool Design");

        Console.WriteLine($"Group name of design department: {toolDesignDepartment.GroupName}");
    }

    {
        var employeeDepartmentHistoryCount = await context
            .EmployeeDepartmentHistory
            .CountAsync();

        Console.WriteLine($"Employee department history records count: {employeeDepartmentHistoryCount}");

        var employeeDepartmentHistoryAfterFilterDate = await context
            .EmployeeDepartmentHistory
            .Where(hist => hist.StartDate.Year < 2010)
            .CountAsync();

        Console.WriteLine(
            $"Employee department history records before 2010: {employeeDepartmentHistoryAfterFilterDate}");
    }

    {
        var employeePayHistoryCount = await context
            .EmployeePayHistory
            .CountAsync();

        Console.WriteLine($"Employee pay history records count: {employeePayHistoryCount}");

        var maxRate = await context
            .EmployeePayHistory
            .MaxAsync(hist => hist.Rate);

        Console.WriteLine($"Max pay rate: {maxRate:C0}");
    }

    {
        var jobCandidatesCount = await context
            .JobCandidate
            .CountAsync();

        Console.WriteLine($"Job candidates count: {jobCandidatesCount}");

        var jobCandidateFromDec2013 = await context
            .JobCandidate
            .FirstAsync(candidate => candidate.ModifiedDate.Year == 2013 && candidate.ModifiedDate.Month == 12);
        
        Console.WriteLine($"Resume of job applicant from December 2013: {jobCandidateFromDec2013.Resume}");
    }

    {
        var shiftsCount = await context
            .Shift
            .CountAsync();

        Console.WriteLine($"Shifts count: {shiftsCount}");

        var nightShiftHours = await context
            .Shift
            .Where(shift => shift.Name.Contains("Night"))
            .Select(shift => new {shift.StartTime, shift.EndTime})
            .FirstAsync();

        Console.WriteLine($"Night shift starting hour: {nightShiftHours.StartTime} ending hour: {nightShiftHours.EndTime}");
    }

    {
        var addressesCount = await context
            .Address
            .CountAsync();

        Console.WriteLine($"Addresses count: {addressesCount}");

        var countOfAddressesInBothell = await context
            .Address
            .Where(address => address.City.Contains("Bothell"))
            .CountAsync();
        
        Console.WriteLine($"Addresses count in Bothell: {countOfAddressesInBothell}");
    }
    
    {
        var addressTypesCount = await context
            .AddressType
            .CountAsync();

        Console.WriteLine($"Address types count: {addressTypesCount}");

        var primaryAddressType = await context
            .AddressType
            .FirstAsync(type => type.Name.Contains("Primary"));

        Console.WriteLine($"Primary address type id: {primaryAddressType.AddressTypeId}");
    }
    
    {
        var businessEntitiesCount = await context
            .BusinessEntity
            .CountAsync();

        Console.WriteLine($"Business entities count: {businessEntitiesCount}");

        var businessEntityByGuid = await context
            .BusinessEntity
            .FirstAsync(type => type.RowGuid.Equals(new Guid("0f3cc1d7-f484-4bde-b088-b11ef03e2f52")));

        Console.WriteLine($"Primary address type id: {businessEntityByGuid.BusinessEntityId}");
    }

    {
        var businessEntitiesAddressesCount = await context
            .BusinessEntityAddress
            .CountAsync();

        Console.WriteLine($"Business entities addresses count: {businessEntitiesAddressesCount}");

        var top5RecentlyModifiedBusinessEntitiesAddressesModifiedDates = await context
            .BusinessEntityAddress
            .GroupBy(businessEntityAddress => businessEntityAddress.ModifiedDate)
            .OrderByDescending(group => group.Key)
            .Select(group => group.Key)
            .Take(5)
            .ToListAsync();


        Console.WriteLine("Recently modified dates:");
        top5RecentlyModifiedBusinessEntitiesAddressesModifiedDates
            .ForEach(modifiedDate  => Console.WriteLine($"=> {modifiedDate.Date:yyyy MMMM dd}"));
    }

    {
        var businessEntitiesContactsCount = await context
            .BusinessEntityContact
            .CountAsync();

        Console.WriteLine($"Business entities contacts count: {businessEntitiesContactsCount}");
        
        var contactTypesCoveredInBusinessEntityContacts = await context
            .BusinessEntityContact
            .GroupBy(businessEntityContact => businessEntityContact.ContactTypeId)
            .CountAsync();

        Console.WriteLine($"Contact types involved in business entity contacts: {contactTypesCoveredInBusinessEntityContacts}");
    }
    
    {
        var contactTypesCount = await context
            .ContactType
            .CountAsync();

        Console.WriteLine($"Contact types count: {contactTypesCount}");

        var contactTypeOfMarketingAssistant = await context
            .ContactType
            .FirstAsync(type => type.Name.Contains("Marketing Assistant"));

        Console.WriteLine($"Contact type of a marketing assistant: {contactTypeOfMarketingAssistant.ContactTypeId}");
    }

    {
        var countryRegionsCount = await context
            .CountryRegion
            .CountAsync();

        Console.WriteLine($"Contact types count: {countryRegionsCount}");

        var countryPoland = await context
            .CountryRegion
            .FirstAsync(country => country.Name.Contains("Poland"));

        Console.WriteLine($"Polish region code: {countryPoland.CountryRegionCode}");
    }

    {
        var emailAddressesCount = await context
            .EmailAddress
            .CountAsync();

        Console.WriteLine($"Email addresses count: {emailAddressesCount}");

        var michaelEmail = await context
            .EmailAddress
            .FirstAsync(email => email.Address.StartsWith("michael6"));

        Console.WriteLine($"Michael email: {michaelEmail.Address}");
    }

    {
        var passwordsCount = await context
            .Password
            .CountAsync();

        Console.WriteLine($"Passwords count: {passwordsCount}");

        var passwordBySalt = await context
            .Password
            .FirstAsync(pass => pass.PasswordSalt.Contains("zNntJNI="));

        var personByPasswordSalt = await context
            .Person
            .FirstAsync(person => person.BusinessEntityId == passwordBySalt.BusinessEntityId);

        Console.WriteLine($"Person with password salt 'zNntJNI=' : {personByPasswordSalt.FirstName} {personByPasswordSalt.LastName}");
    }

    {
        var peopleCount = await context
            .Person
            .CountAsync();

        Console.WriteLine($"People count: {peopleCount}");

        var peopleTypesCount = await context
            .Person
            .GroupBy(person => person.PersonType)
            .CountAsync();

        Console.WriteLine($"People types count: {peopleTypesCount}");
    }
    
    {
        var peoplePhonesCount = await context
            .PersonPhone
            .CountAsync();

        Console.WriteLine($"People phones count: {peoplePhonesCount}");

        var phoneByNumber = await context
            .PersonPhone
            .FirstAsync(phone => phone.PhoneNumber.Contains("984-555-0148"));

        var personWithTheNumber = await context
            .Person
            .FirstAsync(person => person.BusinessEntityId == phoneByNumber.BusinessEntityId);

        Console.WriteLine($"Person with phone number '984-555-0148' : {personWithTheNumber.FirstName} {personWithTheNumber.LastName}");
    }
    
    {
        var phonesNumbersTypesCount = await context
            .PhoneNumberType
            .CountAsync();

        Console.WriteLine($"Phones numbers types count: {phonesNumbersTypesCount}");

        var phoneNumberTypes = context
            .PhoneNumberType
            .Select(type => type.Name);

        Console.WriteLine("Phone number types:");
        await phoneNumberTypes.ForEachAsync(name => Console.WriteLine($"=> {name}"));
    }
    
    {
        var stateProvincesCount = await context
            .StateProvince
            .CountAsync();

        Console.WriteLine($"State provinces count: {stateProvincesCount}");

        var provinceCountForEachState = context
            .StateProvince
            .GroupBy(province => province.CountryRegionCode)
            .Select(group => new
                { State = group.Key, Count = group.Count(p => p.CountryRegionCode.Contains(group.Key)) });
        
        provinceCountForEachState = provinceCountForEachState
            .OrderByDescending(group => group.Count);
        
        Console.WriteLine("Provinces count for each state:");
        await provinceCountForEachState.ForEachAsync(group => Console.WriteLine($"=> {group.State} --- {group.Count}"));
    }
}
