class Order {
  private List<Product> _products;
  private Customer _customer;
  
  public Order(Customer customer) {
    _customer = customer;
    _products = new List<Product>();
  }

  public double GetTotalPrice(){
    double totalPrice = GetShippingCost();
    foreach(Product product in _products){
      totalPrice += product.GetTotalCost();
    }
    return totalPrice;
  }

  private double GetShippingCost(){
    return _customer.LivesInUsa() ? 5.0 : 35.0;
  }

  public string GetPackingLabel() {
    var packingLabels = new List<string>();
    foreach (Product product in _products){
      packingLabels.Add(product.GetPackingLabel());
    }
    return string.Join("\n", packingLabels);
  }

  public string GetShippingLabel() {
    return $"{_customer.GetName()}\n{_customer.GetFullAddress()}";
  }

  public void AddProduct(Product product){
    _products.Add(product);
  }
}