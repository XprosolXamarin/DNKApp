using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DNKApp.Models
{
   public class OrderDetailModel
    {
        //[PrimaryKey, AutoIncrement]
        //public int id { get; set; }
        //public int parent_id => 0;
        //public string number { get; set; }
        //public string order_key { get; set; }
        //public string created_via { get; set; }
        //public string version { get; set; }
        //public string status { get; set; }
        //public string currency => "PKR";
        //public DateTime date_created { get; set; }
        //public DateTime date_created_gmt { get; set; }
        //public DateTime date_modified { get; set; }
        //public DateTime date_modified_gmt { get; set; }
        //public string discount_total { get; set; }
        //public string discount_tax { get; set; }
        //public string shipping_total { get; set; }
        //public string shipping_tax { get; set; }
        //public string cart_tax { get; set; }
        //public string total { get; set; }
        //public string total_tax { get; set; }
        //public Boolean prices_include_tax { get; set; }
        // public int customer_id => 0;
        //public string customer_ip_address { get; set; }
        //public string customer_user_agent { get; set; }
        //public string customer_note { get; set; }
        public string payment_method { get; set; }
        public string payment_method_title { get; set; }
        public Boolean set_paid { get; set; }
        public Billing billing { get; set; }
        public Shipping shipping { get; set; }
       
        //public string transaction_id { get; set; }
        //public DateTime date_paid { get; set; }
        //public DateTime date_paid_gmt { get; set; }
        //public DateTime date_completed { get; set; }
        //public DateTime date_completed_gmt { get; set; }
        //public string cart_hash { get; set; }
       // public List<MetaDate> meta_data { get; set; }
        public List<LineItems> line_items { get; set; }
       // public List<TaxLine> tax_lines { get; set; }
        public List<ShippingLine> shipping_lines { get; set; }
       // public List<FeeLine> fee_lines { get; set; }
       // public List<CouponLine> coupon_lines { get; set; }
      //  public List<Refund> refunds { get; set; }
        
    }
    public class Billing
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company => "";
       
        public string address_1 { get; set; }
        public string address_2 => "";
        public string city { get; set; }
        
        public string state { get; set; }
        
        public string postcode { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        
        public string phone { get; set; }
    }
    public class Shipping
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
       // public string company { get; set; }
        public string address_1 { get; set; }
        public string address_2 => "";
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }
    public class MetaDate
    {
       // public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }
    public class LineItems
    {
      //  public int id { get; set; }
       // public string name { get; set; }
        public int product_id { get; set; }
       // public int variation_id { get; set; }
        public int quantity { get; set; }
        public string tax_class => "";
        public string subtotal { get; set; }
        public string subtotal_tax => "0.00";
        public string total { get; set; }
        public string total_tax => "0.00";
        //public List<Taxes> taxes { get; set; }
        //public List<MetaDate> meta_data { get; set; }
       // public string sku { get; set; }
        public int price { get; set; }
    }
    public class TaxLine
    {
        //public int id { get; set; }
        //public string rate_code { get; set; }
        //public string rate_id { get; set; }
        //public string label { get; set; }
        //public Boolean compound { get; set; }
        //public string tax_total { get; set; }
        //public string shipping_tax_total { get; set; }
        public List<MetaDate> meta_data { get; set; }
    }
    public class ShippingLine
    {
        //public int id { get; set; }
        public string method_id { get; set; }
        public string method_title { get; set; }
       
        public string total { get; set; }
        //public string total_tax { get; set; }
        //public List<Taxes> taxes { get; set; }
       // public List<MetaDate> meta_data { get; set; }
    }
    public class FeeLine
    {
        //public int id { get; set; }
        public string name { get; set; }
        public string tax_class { get; set; }
        public string tax_status => "None";
        public string total { get; set; }
        //public string total_tax { get; set; }
        //public List<Taxes> taxes { get; set; }
        public List<MetaDate> meta_data { get; set; }
    }
    public class CouponLine
    {
       // public int id { get; set; }
        public string code { get; set; }
        //public string discount { get; set; }
        //public string discount_tax { get; set; }
        public List<MetaDate> meta_data { get; set; }
    }
    public class Refund
    {
        //public int id { get; set; }
        //public string reason { get; set; }
        //public string total { get; set; }
    }
    public class Taxes
    {
        //public int id { get; set; }
        //public string rate_code { get; set; }
        //public string rate_id { get; set; }
        //public string label { get; set; }
        //public Boolean compound { get; set; }
        //public string tax_total { get; set; }
        //public string shipping_tax_total { get; set; }
        public List<MetaDate> meta_data { get; set; }
    }
}
