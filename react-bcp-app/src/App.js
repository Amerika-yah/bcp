import logo from './logo.svg';
import './App.css';
import { Container, Nav, Navbar } from 'react-bootstrap';
import { BrowserRouter, Route } from 'react-router-dom';

function App() {
  return (
    <Container>
      <BrowserRouter>
        <Navbar bg="dark" variant="dark">
          <Navbar.Brand as={Link} to="/">BCP</Navbar.Brand>
          <Nav className='mr-auto'>
            <Nav.Link as={Link} to="/">Home</Nav.Link>
            <Nav.Link as={Link} to="/login">Login</Nav.Link>
          </Nav>
        </Navbar>
        <Switch>
          {/* <Route exact path="/" Component={() => } */}
          <Route exact path="/admin/dashboards" component={Actors} />
        </Switch>
      </BrowserRouter>
    </Container>
  );
}

export default App;
