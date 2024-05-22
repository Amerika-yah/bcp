import React, {useEffect, useState} from "react";

import UserItem from "./user-items";

const UserList = () => {
    const[users, setUsers] = useState(null);
    const[usersCount, setUsersCount] = useState(0);
    const[page, setPage] = useState(0);

    useEffect(() => {
        //get all users
        getUsers();
    }, [page]);
    
    const getUsers = () => {
        fetch(process.env.REACT_APP_API_URL + "/user?pageSize=" + process.env.REACT_APP_PAGING_SIZE + "&pageIndex=" + page)
        .then(res => res.json())
        .then(res => {
            if(res.status === true && res.data.count > 0){
                setUsers(res.data.movies);
                setUsersCount(Math.ceil(res.data.count / process.env.REACT_APP_PAGING_SIZE));
            }
            if(res.data.count === 0){
                alert("There's no user data in the system. Hallo hallo hallo");
            }
        })
        .catch(err => alert("Error getting data"));
    }

    return (
        <>
            {/* {users && users !== [] ?  */}
            {users && users.items ?
            users.map((m, i) => <UserItem key={i} data={m} />)
        : ""}
        </>
    )
}

export default UserList;