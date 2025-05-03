

export default function UserItem(props) {

    const {user} = props;

    return(<>
        <h2>{user.name}</h2>
        <p>{user.email}</p>
        <img src={user.avatar} alt={user.name} width={50} style={{borderRadius: '50%'}}/>
    </>)
}