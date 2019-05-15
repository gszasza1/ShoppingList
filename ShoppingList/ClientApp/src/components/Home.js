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
       
      </div>
    );
  }
}
