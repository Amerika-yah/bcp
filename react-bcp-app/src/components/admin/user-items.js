import React from "react";
import { Row, Count, Col } from 'react-bootstrap';


const UserItem = (props) => {
    
    return (
        <>
            <Row>
                <Col>
                    <div><b>{props.data.EmpID}</b></div>
                </Col>
                <Col>
                    <div><b>{props.data.Firstname}</b></div>
                </Col>
                <Col>
                    <div><b>{props.data.Lastname}</b></div>
                </Col>
            </Row>
        </>
    )
}

export default UserItem;