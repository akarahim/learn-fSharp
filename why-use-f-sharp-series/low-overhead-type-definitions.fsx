open System
type PersonalName = {FirstName:string;LastName:string}

type StreetAddress = {Line1:string;Line2:string;Line3:string}
type ZipCode = ZipCode of string
type StateAbbrev = StateAbbrev of string
type ZipAndState = {State:StateAbbrev;Zip:ZipCode}

type USAddress = {Street:StreetAddress;Region:ZipAndState}

type UKPostCode = PostCode of string
type UKAddress = {Street:StreetAddress;Region:UKPostCode}

type InternationalAddress = {Street:StreetAddress;Region:string;CountryName:string}

//choice type
type Address = USAddress|UKAddress|InternationalAddress

type Email = Email of string
type CountryPrefix= Prefix of int
type Phone={CountryPrefix:CountryPrefix;LocalNumber:string}

type Contact = 
    {
    PersonalName:PersonalName;
    //"option" means it might be missing
    Address:Address option;
    Email:Email option;
    Phone:Phone option;
    }
type CustomerAccountId=AccountId of string
type CustomerType=Prospect|Active|Inactive
//override Equality and deny comparison
[<CustomEquality;NoComparison>]
type CustomerAccount=
    {
        CustomerAccountId:CustomerAccountId;
        CustomerType:CustomerType;
        ContactInfo:Contact;
    }
    override this.Equals(other)=
        match other with   
        | :? CustomerAccount as otherCust ->
            (this.CustomerAccountId) =  otherCust.CustomerAccountId
        |_->false
    override this.GetHashCode() = hash this.CustomerAccountId