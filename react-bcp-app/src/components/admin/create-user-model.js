import React, {useEffect, useState} from "react";

const CreateUserModel = () => {
    const[users, setUsers] = useState(null);
    const[usersCount, setUsersCount] = useState(0);
    const[page, setPage] = useState(0);

    useEffect(() => {
        //get all users
    }, [page]);
    
    const getUsers = () => {
        fetch()
    }

    return (
        <div>
            Musta musta musta...
        </div>
    )
}

export default CreateUserModel;