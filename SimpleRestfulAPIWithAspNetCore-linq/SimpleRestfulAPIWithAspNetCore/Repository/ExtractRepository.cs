using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;

namespace SimpleRestfulAPIWithAspNetCore.Repository
{
    public class ExtractRepository
    {
        //private readonly MySQLContext _context;

        public ExtractRepository(/*MySQLContext context*/)
        {
            //_context = context;
        }

        public Extract GetExtract()
        {
            return MockExtract();
        }

        private Extract MockExtract()
        {
            return new Extract
            {
                Id = 1,
                Master = MockMaster(),
                Detail = MockDetails(),
            };

        }

        private Master MockMaster()
        {
            return new Master()
            {
                Id = 1,
                Address = "Grand Avenue 24, Tajikistan",
                Balance = "15000",
                CardLimit = "600000",
                CardNumber = "4115609595135957",
                ClientName = "Gabriel Clark",
                ExpirationDate = "05/2022"
            };
        }

        private List<Detail> MockDetails()
        {
            return new List<Detail>(new List<Detail>
            {
                new Detail {
                    Id = 1,
                    EmporiumName = "Sônia e Pedro Henrique Fotografias ME",
                    EmporiumCNPJ = "76.520.111/0001-90",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "01022018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "4450",
                    TotalValue = "4450",
                },
                new Detail {
                    Id = 2,
                    EmporiumName = "Luiza e Kaique Restaurante ME",
                    EmporiumCNPJ = "34.816.002/0001-75",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "08022018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "1500",
                    TotalValue = "1500",
                },
                new Detail {
                    Id = 3,
                    EmporiumName = "Mariane e Tereza Casa Noturna ME",
                    EmporiumCNPJ = "49.187.356/0001-75",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "05022018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "3000",
                    TotalValue = "3000",
                },
                new Detail {
                    Id = 4,
                    EmporiumName = "Caleb e Paulo Locações de Automóveis ME",
                    EmporiumCNPJ = "79.502.029/0001-21",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "07032018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "2000",
                    TotalValue = "2000",
                },
                new Detail {
                    Id = 5,
                    EmporiumName = "Noah e Emanuelly Entulhos ME",
                    EmporiumCNPJ = "03.954.164/0001-46",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "04032018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "650",
                    TotalValue = "650",
                },
                new Detail {
                    Id = 6,
                    EmporiumName = "Ricardo e Bento Gráfica ME",
                    EmporiumCNPJ = "92.529.188/0001-88",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "13032018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "500",
                    TotalValue = "500",
                },
                new Detail {
                    Id = 7,
                    EmporiumName = "Henry e Iago Eletrônica Ltda",
                    EmporiumCNPJ = "28.243.550/0001-50",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "18042018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "7000",
                    TotalValue = "7000",
                },
                new Detail {
                    Id = 8,
                    EmporiumName = "Isis e Renato Casa Noturna ME",
                    EmporiumCNPJ = "91.636.065/0001-83",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "22042018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "450",
                    TotalValue = "450",
                }
            ,
                new Detail {
                    Id = 9,
                    EmporiumName = "Marcelo e Lavínia Locações de Automóveis Ltda",
                    EmporiumCNPJ = "01.290.840/0001-07",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "09042018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "500",
                    TotalValue = "500",
                }
            ,
                new Detail {
                    Id = 10,
                    EmporiumName = "Vinicius e Cristiane Marketing Ltda",
                    EmporiumCNPJ = "62.310.132/0001-77",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "03052018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "1220",
                    TotalValue = "1220",
                }
            ,
                new Detail {
                    Id = 11,
                    EmporiumName = "Isabel e Gabriela Alimentos ME",
                    EmporiumCNPJ = "90.961.559/0001-70",
                    Longitude = "-1.252303",
                    Latitude = "-48.42747",
                    OperationDate = "17052018",
                    OperationTime = "0827",
                    OperationType = "COMPRA",
                    Value = "1300",
                    TotalValue = "1300",
                }
            });
        }

    }
}
