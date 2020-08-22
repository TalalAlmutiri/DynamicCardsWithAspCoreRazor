# DynamicCardsWithAspCoreRazor
ASP core with Razor that displays responsive cards horizontally and vertically using Materialize.css


Products table

    CREATE TABLE [dbo].[Products](
      [ProductID] [int] NOT NULL,
      [ProductName] [varchar](50) NULL,
      [ProductDesc] [varchar](100) NULL,
      [ProductPrice] [float] NULL,
      [ProductImage] [varchar](50) NULL,
     CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
    (
      [ProductID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    INSERT INTO Products VALUES(1,'PC 1','HP Personal computer',1000,'pc1.jpg')
    INSERT INTO Products VALUES(2,'PC 2','Dell Personal computer',1200,'pc2.jpg')
    INSERT INTO Products VALUES(3,'PC 3','Apple Mac 1',1400,'pc3.jpg')
    INSERT INTO Products VALUES(4,'PC 4','Apple Mac 2',1800,'pc4.jpg')


ProductsRepository.cs

    public class ProductsRepository: IProductsRepository
      {
           public IEnumerable<Products> GetAllProducts()
          {
              List<Products> productsList = new List<Products>();

              string query = @"SELECT * FROM Products Order By ProductID";
              DataTable table = DbHelper.ExecuteQuery(query, CommandType.Text, null);

              if (table.Rows.Count > 0)
              {
                  for (int i = 0; i < table.Rows.Count; i++)
                  {
                      Products products = new Products();
                      products.ProductID = Convert.ToInt32(table.Rows[i]["ProductID"]);
                      products.ProductName = table.Rows[i]["ProductName"].ToString();
                      products.ProductDesc = table.Rows[i]["ProductDesc"].ToString();
                      products.ProductPrice = float.Parse(table.Rows[i]["ProductPrice"].ToString());
                      products.ProductImage = table.Rows[i]["ProductImage"].ToString();

                      productsList.Add(products);
                  }
              }
              return productsList;
          }
      }


Vertical cards Products.cshtml

![CardImg1](https://user-images.githubusercontent.com/62042702/90954460-11dd9280-e47d-11ea-9ad8-2a7168f0f0d0.png)

    @model IEnumerable<DynamicCardsWithAspCoreRazor.Models.Products>

        <link href="~/css/materialize.min.css" rel="stylesheet" />
        <link href="~/css/Custom.css" rel="stylesheet" />
        <div id="products-container" class="container">
            @if (Model != null)
            {
                @foreach (var item in Model)
                {
                    <div class="row">
                        <div class="col s12 l12 m12">
                            <div class="card rounded">
                                <h3 class="center teal-text"> @Html.DisplayFor(modelItem => item.ProductName)</h3>
                                <div class="card-image">
                                    <img src="/ImgProducts/@Html.DisplayFor(modelItem => item.ProductImage)" />
                                </div>
                                <div class="card-content teal center white-text no-padding">
                                    <span class="card-title"><b> @Html.DisplayFor(modelItem => item.ProductPrice) $ </b></span>
                                    <p>
                                        @Html.DisplayFor(modelItem => item.ProductDesc)
                                    </p>
                                </div>
                                <div class="card-action teal center">
                                    <a class="btn  amber darken-4 white-text">View</a>
                                </div>
                            </div>
                        </div>
                    </div>
                }
            }
        </div>



ProductsHorizontal.cshtml

  
 ![CardImg2](https://user-images.githubusercontent.com/62042702/90954445-02f6e000-e47d-11ea-9f20-3e677b0539a6.png)
 

![card2](https://user-images.githubusercontent.com/62042702/90954506-78fb4700-e47d-11ea-877e-bc0671d75745.png)


    @model IEnumerable<DynamicCardsWithAspCoreRazor.Models.Products>

    <link href="~/css/materialize.min.css" rel="stylesheet" />
    <link href="~/css/Custom.css" rel="stylesheet" />
    <div class="container">
        @if (Model != null)
        {
                <div class="row">
                    @foreach (var item in Model)
                    {
                    <div class="col s12 m12 l6 xl3">
                        <div class="card rounded">
                            <h3 class="center teal-text"> @Html.DisplayFor(modelItem => item.ProductName)</h3>
                            <div class="card-image">
                                <img class="img" src="/ImgProducts/@Html.DisplayFor(modelItem => item.ProductImage)" />
                            </div>
                            <div class="card-content teal center white-text no-padding">
                                <span class="card-title"><b> @Html.DisplayFor(modelItem => item.ProductPrice) $ </b></span>
                                <p>
                                    @Html.DisplayFor(modelItem => item.ProductDesc)
                                </p>
                            </div>
                            <div class="card-action teal center">
                                <a class="btn  amber darken-4 white-text">View</a>
                            </div>
                        </div>
                    </div>
                    }

                </div>

        }
        </div>

