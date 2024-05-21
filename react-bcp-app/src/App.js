import logo from './logo.svg';
import './App.css';
import { Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import { BrowserRouter, Route, Link, Routes } from 'react-router-dom';
import Users from './pages/admin/dashboard';
import Login from './pages/login/login';

function App() {
  return (
    <Container>
      <BrowserRouter>
        {/* <Navbar bg="dark" variant="dark">
          <Navbar.Brand as={Link} to="/">BCP</Navbar.Brand>
          <Nav className='mr-auto'>
            <Nav.Link as={Link} to="/">Home</Nav.Link>
            <Nav.Link as={Link} to="/login">Login</Nav.Link>
          </Nav>
        </Navbar> */}
        <Navbar expand="lg" bg="dark" data-bs-theme="dark">
          <Container>
            <Navbar.Brand as={Link} to="/">BCP</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className='mr-auto'>
                <Nav.Link as={Link} to="/">Home</Nav.Link>
                <Nav.Link as={Link} to="/login">Login</Nav.Link>
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>
        <Routes>
          <Route exact path="/" Component={() => <Users />} />
          <Route exact path="/admin/dashboards" Component={Login} />
        </Routes>
      </BrowserRouter>
    </Container>
  );
}

export default App;
