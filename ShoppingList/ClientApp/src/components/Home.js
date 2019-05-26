import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <h1>Üdvözöllek</h1>
        <p>.Net házimat látod</p>
        <p>Alapkoncepció egy lista, ahol Ételeket vehetsz fel, bevásárló listát készíthetsz, stb..</p>
        <h3>Megvalósítás:</h3>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> és <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> a cross-platform server-side kódért</li>
          <li><a href='https://facebook.github.io/react/'>React</a> a client-side kódért</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> a nézet miatt</li>
          <li><a href='https://docs.microsoft.com/en-us/ef/core/'>Entity Framework Core</a> az adatbázis és modellekért</li>
        </ul>
        <p>Projekt felépítése</p>
        <ul>
          <li><strong>Models</strong>. Leírja milyen modellek léteznek  az alkalmazásnak, e-szerint van az adatbázis is</li>
          <li><strong>Services</strong>. Kezeli az adatbázist, és modelleket</li>
          <li><strong>Controllers</strong>. Kliens oldalról érkező kéréseket fogadja, feldolgozza. Servicesen keresztül kommunikál adatbázissal.</li>
        </ul>
        <h3>Mik vannak benne a követelményből:</h3>
        <ul className="ulstyled">
          <li>
          Web API Core által alapból nem támogatott HTTP ige implementálása
          <ul className="ulstyled_2">
            <li >
            pl. GET-hez hasonló működés <strong>5</strong>
            </li>
          </ul>
          </li>
          verziókezelt API
          <ul className="ulstyled_2">
            <li >
            nem HTTP header (pl. URL szegmens) alapján <strong> 7</strong> NEED
            </li>
          </ul>
          <li>
          Publikálás docker konténerbe és futtatás konténerből <strong> 7</strong> NEED
          </li>
          <li>
             Table splitting  <strong>5</strong>
          </li>
          <li>
          adatbázis index konfigurációja az EF modellben <strong>3</strong>
          </li>
          <li>
          birtokolt típus (owned type) használata <strong>3</strong>
          </li>
          <li>
          értékkonverter (value converter) alkalmazása EF Core leképezésben
          <ul className="ulstyled_2">
            <li >
            beépített value converter <strong>3</strong>
            </li>
          </ul>
          </li>
          <li>
          Optimista konkurenciakezelés 
          <ul className="ulstyled_2">
            <li >
            ütközésdetektálás és automatikus ütközésfeloldás <strong>5</strong>
            </li>
          </ul>
          </li>
          <li>
          hosztolás külső szolgáltatónál 
          <ul className="ulstyled_2">
            <li >
            Windows Azure <strong>7</strong>
            </li>
          </ul>
          </li>
          <li>
          logikai törlés (soft delete) globális szűrőkkel (Global Query Filter) <strong>5</strong>
          </li>
          <li>
          külső osztálykönyvtár használata<strong> 7</strong>
          </li>
        </ul>
<h3>Total:57</h3>
      </div>
    );
  }
}
