import React from "react";
import { Row, Col, Button } from 'react-bootstrap';

// import MovieList from '../components/userlist.js';

const Dashboard = () => {


    return (
        <>
        <Row>
            <Col xs={12} md={10}>
                <h2>Users</h2>
            </Col>
            <Col xs={12} md={10} className="align-self-center">
                <Button className="float-right" onClick={() => {}}>Add User</Button>
            </Col>
        </Row>
        </>
    )
}

export default Dashboard;