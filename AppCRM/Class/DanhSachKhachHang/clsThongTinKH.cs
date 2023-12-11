using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BankAccount
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BankId
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BillAddress
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BillAreaCode
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BillCity
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BillDistrict
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BillInvoiceAddress
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BillWard
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BusinessAreas
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class BusinessType
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Category
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class CitId
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Classify
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class DataThongTinKH
    {
        public string cus_id { get; set; }
        public Email email { get; set; }
        public PhoneNumber phone_number { get; set; }
        public string name { get; set; }
        public StandName stand_name { get; set; }
        public string logo { get; set; }
        public string birthday { get; set; }
        public string tax_code { get; set; }
        public CitId cit_id { get; set; }
        public DistrictId district_id { get; set; }
        public Ward ward { get; set; }
        public Address address { get; set; }
        public ShipInvoiceAddress ship_invoice_address { get; set; }
        public string gender { get; set; }
        public string cmnd_ccnd_number { get; set; }
        public string cmnd_ccnd_address { get; set; }
        public string cmnd_ccnd_time { get; set; }
        public Resoure resoure { get; set; }
        public Description description { get; set; }
        public object introducer { get; set; }
        public object contact_name { get; set; }
        public object contact_email { get; set; }
        public object contact_phone { get; set; }
        public string contact_gender { get; set; }
        public string company_id { get; set; }
        public EmpId emp_id { get; set; }
        public string user_handing_over_work { get; set; }
        public string user_create_id { get; set; }
        public string user_create_type { get; set; }
        public string user_edit_id { get; set; }
        public string user_edit_type { get; set; }
        public GroupId group_id { get; set; }
        public Status status { get; set; }
        public BusinessAreas business_areas { get; set; }
        public Classify classify { get; set; }
        public BusinessType business_type { get; set; }
        public Category category { get; set; }
        public BillCity bill_city { get; set; }
        public BillDistrict bill_district { get; set; }
        public BillWard bill_ward { get; set; }
        public BillAddress bill_address { get; set; }
        public BillAreaCode bill_area_code { get; set; }
        public BillInvoiceAddress bill_invoice_address { get; set; }
        public object bill_invoice_address_email { get; set; }
        public string ship_city { get; set; }
        public ShipArea ship_area { get; set; }
        public BankId bank_id { get; set; }
        public BankAccount bank_account { get; set; }
        public Revenue revenue { get; set; }
        public Size size { get; set; }
        public Rank rank { get; set; }
        public Website website { get; set; }
        public string number_of_days_owed { get; set; }
        public DebtLimit debt_limit { get; set; }
        public string share_all { get; set; }
        public string type { get; set; }
        public string is_input { get; set; }
        public string is_delete { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string id_cus_from { get; set; }
        public object cus_from { get; set; }
        public object link { get; set; }
        public string gr_id { get; set; }
        public string gr_name { get; set; }
        public string stt_name { get; set; }
        public string role { get; set; }
        public string share_related_list { get; set; }
        public string user_create_name { get; set; }
        public string user_edit_name { get; set; }
        public List<object> history_edit_customer { get; set; }
    }

    public class DebtLimit
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Description
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class DistrictId
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Email
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class EmpId
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class GroupId
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class PhoneNumber
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Rank
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Resoure
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Revenue
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class clsThongTinKH
    {
        public bool result { get; set; }
        public string message { get; set; }
        public DataThongTinKH data { get; set; }
    }

    public class ShipArea
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class ShipInvoiceAddress
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Size
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class StandName
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Status
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Ward
    {
        public string info { get; set; }
        public string detail { get; set; }
    }

    public class Website
    {
        public string info { get; set; }
        public string detail { get; set; }
    }


}
