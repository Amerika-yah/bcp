import React from "react";
import { Row, Col, Button } from 'react-bootstrap';

import UserList from "../../components/admin/userlist";
import CreateUserModel from "../../components/admin/create-user-model";


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

        <UserList />
        <CreateUserModel />


        </>
    )
}

export default Dashboard;