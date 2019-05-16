import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>ShoppingList</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Főoldal
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/meals'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Ételek
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/shoppinglists'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Bevásárlólisták
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/shoppinglistsoptions'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Bevásárlólista opciók
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/addfoodtolist'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Étel felvétel listára
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/peoples'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Személyek
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
