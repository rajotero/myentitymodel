using eBay.Service.Core.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    class myEbay
    {
        public static ApiContext GetContext(string cuenta)
        {
            if (String.IsNullOrEmpty(cuenta))
                cuenta = "ofertasparati";
            ApiContext context = new ApiContext();
            //set the your credentials
            if (String.Equals("garfo_es", cuenta, StringComparison.OrdinalIgnoreCase))
                context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**VdgWWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkYKkCpGEqA2dj6x9nY+seQ**EnwDAA**AAMAAA**CcNW7u+xZTaHfw5LoCboEhnVlgpxnB9sZR74o8hbwWsQAYR2PR6+2duCdMgZIt6x22NWtbJGqijpsee6fDOXBTsQ0F0PMhcLtojm9vDuYMSgoQBUZKcwEi+gnuGBodJT2E1srJe" +
                                                  "eKaUFHFHjsSU3P49xQfVduXfWRK81bD4qWVWQP4m1NdAnlgAdFq9Zo4zOn/c9oNUjdP5uvXRrOenHR7U9bIFTXBYDhjn7RVijewqrPSOet9xLT6JSentEKKeUiw1d1PpSne4sKbnmmABRC+MxdMXxonkOuuYTi8xlJ7niigIQ95imcxL5bE7hQh1exmiFVNHwwTp8nPy1PzsRSOA0MSECpgNmAtw+eVkjNfv2PSfk9fkcMB" +
                                                  "Vxt/+S5/Bzesys7lLjOYCyZMA8k5z+4ht7Lu4qidqHrDJ6Z5bcp3oZEVa1rTQWUFVQwi2GHSNKjr61n00hOfczEJTrXTTjaZofZngcyzcf3ElsdqieEs9VbpMxrzFtsAPhevKgWWt37SROQMmj9t6OfgWcvPcP5oChklqxuLWPYsHZACqZqYI22SOBL/fzLhGYpdMEzLJ4ufKzI98j4hJhxhDgT3M/R54bf+fXBe+VoDplF" +
                                                  "7I9i2p4q347+c+rGgeYiqcgjw1CbEzBrZtHXTgihes0O7GSe0y5LtLycT5TmUo0nz3uLWd8QiQChWIFHq+0f/1r/hPCmDr9Qoz2naXtID7p9y6qBPFQ1lPy1/dOiGH9M3msKPm/8wSl/mHo/+qjpgfHKON6";
            if (String.Equals("ofertasparati", cuenta, StringComparison.OrdinalIgnoreCase))
                context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**yNgWWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wHmIKoDpSDoASdj6x9nY+seQ**EnwDAA**AAMAAA**QeHtNXsJiQlV5YrPRkm4sgQ2IVJJvuk+z79VjiJxL+ofzRLHSQl3S2UykWJv8t5LLCNu2YgFskz6txbK3XBf4ij7iKfNOlFwjQG2yjcIna039UivZkzPdc8ZRw/Eh9ldOSwd/uL" +
                                                  "soqGk9RnToyFniG80rnlmOZC6XTfvsyYj5cRAzH0pJzCDhXoJuWn2pmuGQdmHNYJw2fHrVWoTeBIwXAXNHe2M6Ucoe2ZBaG1dCZEjPP2CbwEuELQy0ptsuQ6reGHDIMOVruagKB2km2UnGpIA8Gwj5sCGahE5EivMd6MHe6Scjf0PXFCV3oz60ilCq77XJPdmrYlhIegLtpL/04OhccXmilOcUSGqHxh2eq5AUKGZ17QyrY" +
                                                  "bg9ZUgkTHnhijVzWtUm9s/DFR2uYYi3lYBOn5AP3IRagYCWYXtS0yfooVxl/QwalUitIUZ6KFfS5Zs8v3yhDNiKwuXn8jwT0j/mK/Ee98OPLUEGGerBkLzh+6Ly/fVFCrdKU3Mt8HwuKcmZePI+ahnC4jhwf9WBWbo8PqAAKUjdfu2NPg/PJ8jenAzpPqFRd+/ERravJOEn4qrntHBjhHslmDxHPk6dyCNPhaZ4cfjSTZgo" +
                                                  "ExWlBaEgiCuRlOB5IglWiFWtpOxrHqD44ZKRhRSCDvdJ2PaL8sENFH4MqjYTi1vvPWaWqEtpq5p4pNGQMw3cA5DlQhx4qNUfjCNufqCjdXdD1h0auIiR9nMTu7xK/b4uRYl+pchmufJFpyXu+nvbYrkLBT3";
            if (String.Equals("rajotero", cuenta, StringComparison.OrdinalIgnoreCase))
                context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**ktgWWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkIeiD5WLoQidj6x9nY+seQ**EnwDAA**AAMAAA**mEvFBeGLDRzhvoIZjeCtitoYHzCiaQqTDtuSRlqtL4SZJyTw6ITN25SIdV/nlyJOmdsYKp4Udw8Jn8yDDkY2R24K1dAy9jkqm8o/aT8NK8JS9Rap8lTK2O7+GQkaXm1P" +
                                                    "yUtRI3Jip/a1ZGpwzrkj+c0T91MuNwfv8NCslquhyJY9Ofty30dANFRH8tt50wj1FlojGU+POYxgPEspvx8bkzZ0p7fxLT7X/C9qaSvHGObFm0QQIeoruk/TWgRlqEghyjLfpn91fOeYawHKJR84A8NkC4lVxV1D5JKlKcVuPmQwzvu6k11BEsJc66wnVlUy2nNQZOwTF2bWh48RQ/aN/GMYNnHwiIVJgHCi97Gj" +
                                                    "I5Eu4RCWxkhqmHpvdaFeRTuKMzB0AjuQsgCEqCR1z+iI1OX3LEyaRfSPOpN8+umRUBE0J1sp/xhgdYYYX1Ju+378xCHXv0zoquQ+xnQf5jXSRliDaFKKU6joCfx03+EfHT6XHFAf1BfWQbrov0QXGgnw8m910/olxIEQ2pf2Tspegq4MigNV8XB2+MEcnjjhJ1YIAyealuJTb75lco3mj4I31ATIlM6Nz4aKT967" +
                                                    "QlFNokd+4o8KhI9JocDgSR/1ZbMOZSox9fgbfiIVvzCTFAohiH//rKk/cCag/r+BMnWCSCqymGT8avgugtNO+aPt1Hz/yzxNSE5qvttZ53uzErArht+9Em8IuloQYiog6fxbs6Ax3S5+4v8clh35Mxm/GMATC45sIuM0nVAihcvKazI+";
            context.ApiCredential.ApiAccount.Application = "antoniog-aplicaci-PRD-abffbb311-3e317c6b";
            context.ApiCredential.ApiAccount.Developer = "05759dff-3209-4e96-8701-1f0a8090492b";
            context.ApiCredential.ApiAccount.Certificate = "PRD-bffbb311ca07-b79d-4814-aabe-ee17";



            //if (String.Equals("garfo_es", cuenta, StringComparison.OrdinalIgnoreCase))
            //    context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**SvcOWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkYKkCpGEqA2dj6x9nY+seQ**VXoDAA**AAMAAA**FNZK+I1t+bcHwOvZ8r0dUXRSFJzUSz+EzGorKHFUdDe5Xa++Xw1SA/VFb/xJt5fj6dve58c7T4UJHh9vPhDWK4o6Pbzr3mvw3xdfhtlXo2mSxA4hitSCYV9asoA57HGdwlGRVbs" +
            //                                        "PfzV4eIN1YAI2HxHfK668XP7j0c/BK6EWmQMX4XUD1xH7rOEj5lFck+MEjOY6xJROpCl9sXmCGy3Gkygx55XNKxM05QDdg/UQQ82e/5hHO9VvDHUDYJTqgDBd+mP/e0T63SjMbXjTdPXVZvXjYhKrieZd3tW9KM/ff2w0kQHfQJww4Xcq0U389OSv0g2aSGiuEELyZ8DAcjojqiVOT94OYlQjYxEIpZpNcM165dusIhVHaJ" +
            //                                        "9LZddv8HsBcUMr/O3eVTWN8cVz/FM0SEvnlpPT8f9Es9y00KH5rSbmf5suNyCs0gClqqb7lh2qf8kwLtZio2ShVqtHFQkwXI0swI6nQZITAzBeOY5TeAKNVlIHdg/WgwHIcJuhQwRV63YQUmYBPlSpHKCb/yOklseKkBJy4MLBG1Y+rvGzTvkBr1EW7SAoujCNI7pq8vQA0W6If0+Q3WpAlADwq27CG9wfCCg2utKvNIYXY" +
            //                                        "P2jhaLCvQ2M3JaQ0lmMG/2MP0TMlALe23JgoZQ9O87UG3XNJXN5ri4cKAXAxIc//xAYiRkryrW72iwfd4Ma7DmNRX0NdenwYByOPb9/gL76VjnIF1kvGFUo4C087UcUDsY99uNOMgPLv+Deu9YBU3R8hiFV";


            //if (String.Equals("rajotero", cuenta, StringComparison.OrdinalIgnoreCase))
            //    context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**gvcOWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkIeiD5WLoQidj6x9nY+seQ**VXoDAA**AAMAAA**ako5dZhSP1cXFKfqxu25HWRFPGyDgPFPsOIxWdIweVHVtoFgmvkD6oHyeb/7DbR8ICUSygakQSCabEHQETjJ6e82CAgTYLAL+/HiTelADLYDVLc5rNoAu+R3+NhLIwof" +
            //                                        "wFZbzAJDnBJw9K4oheKx2TWly8orO57GLopWxzgVtYbu98g2SZ2mqb1KYSKGURxVgLTJ51X2A5IESVAHD14Pu8unKrb2K7vTVx69jgvpb5aoGzmAOMPGiyruoVabrxRrZHYwe2p7kHUi2suk7Ut+FE6JWr9zks2TqZOD37ESZ1Gt/QoB3J7rQn0gqKwhoVJ4ZyNBLKtHsP+PMnbmvbsJ8+UyHsZZalTUIhgOYDEq" +
            //                                        "xxDzqQujxE61JM9cEbAVOnzCLB+cs26rSYgZVSI+EUkM3EhQF2tlY9FHB0O1t3tukdoqEUglvRgvgE8DHbABdgUga6NXfkp+0bu14a3gBPGW327BETY7Dto3C6JBG5pLlXPRjWg/lqjMzcNC4hvpaFRIGR1YO11l+6x44kPP8agLJKqCVfh7+w+MM1hW7S2iqqXeKzL9g4hZHP5s9f4RlI9fRh4MejOuo+Mj9TSL" +
            //                                        "OBqUhqbFflKhn9kwOU/KJ1LwLdMkVx5jIGTby9NFQASriZsKLo+du5zs7YJjBbuloQtuJ4kBHW7MEi3t5xXYta4YSx2RHNnieTCuMS/dODlXYApVFEG8erGDJU2/POW+6Ex0mp/Gs2K83490PI4Y4rHP7lP6McgbIBenq4LpRcByLCr7";

            //if (String.Equals("ofertasparati", cuenta, StringComparison.OrdinalIgnoreCase))
            //    context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**svcOWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wHmIKoDpSDoASdj6x9nY+seQ**VXoDAA**AAMAAA**aqyQWWjoV65R5aLmJuLaUU+53aCc9i0Ei2ueoGwGbocWX0D7wDqHAFrrOsJ4G9Pck+XuKKcMFBB7/UUEEI6PdpRoOcWAmA19jz7F6Jj7zYA6YERw/Va3heEHW5eUvXdYB7Sa2NH" +
            //                                        "9iOLkfmSSToe5+Y32Gbad/GWVgEzcGYI0YuAsCNRaEuLD6n92HQP6q0o78UpMWcixjmMLM3/OldfJXNTTjuVCJ/xLD+c6IdV5DDmpD7i3CW9saYE1yKBn+DUMIj0JPH0+QyuxPF0WlAkgZHh+iqi+QxrXctpaH+3FntHPH3zX9idNxTm/BdClpeH7mBolms7YGB0D3T/e4zLf94cQ54tReE8etmtXZjQ8lD3kSZ3Ezy3Bu2" +
            //                                        "KWsaN53XH4FlOTj/OJiItefLjA0b9RbPdCnimVfSfnLP9n9xz7B0iVPdD05Bk9L6H06aiDIViMwhLzX9CeWpEwYH8FxteXHd7sJfIF7OO4FfF9Aaaioy1HAGpeG2l6MN9Daa0o2cErRr2RcgIZRYjhaXKn6zk3N7++R8o6kIW+7OIqFiyWGKH7MqU8y56yR4p+U1bWYITZ/H5yGK1D2E3ZYyRKfjUTd/SS7HeGJmI/MfgPH" +
            //                                        "Q4ocWI+XB0ygLscm3wcIRtH4UsnZmYxNhvnuoO1B1ze/K7e8hHPbfCeHvPMIWyfmXNbeAQoxEkvqoQcY8NtOtuXtJXsKFFIM22cgbxVd2acTEbUDuI2p3Y9dAjzRRp/KIYzWIerETgDkvkZRArpYTZPN2FU";


            //context.ApiCredential.ApiAccount.Application = "Antoniog-aplicaci-PRD-6bffbb311-ad590b91";
            //context.ApiCredential.ApiAccount.Certificate = "PRD-bffbb31175c2-2c3a-40dd-8bca-5e26";
            //context.ApiCredential.ApiAccount.Developer = "fb30edde-186c-4f61-81e6-6c2768dcb5c6";

            context.SoapApiServerUrl = "https://api.ebay.com/wsapi";
            context.Version = "1003";
            return context;
        }

    }
}
