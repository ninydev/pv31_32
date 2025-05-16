import {useState} from "react";
import './style.css'

export function FirstAvatarUpload() {

    const [avatarUrl, setAvatarUrl] = useState(null);
    const [avatarBody, setAvatarBody] = useState(null);

    const onSubmit = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        fetch('http://localhost:3000/upload', {
            method: 'POST',
            body: formData,
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            setAvatarUrl(data.url)
            e.target.reset();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    const uploadImage = (e) => {
        e.preventDefault()
        const file = e.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setAvatarBody(reader.result);
            };
            reader.onerror = (error) => console.error('Error: ', error)
            reader.readAsDataURL(file);
        }
    }

    return(<div>
        <h1>First Avatar Upload</h1>
        <p>Upload your first avatar here.</p>
        <form onSubmit={onSubmit} encType="multipart/form-data">
            <input onChange={uploadImage} type="file" accept="image/*" name="file" />
            <input type="submit" value="Upload" />
        </form>
        <div>
            <div style={{width: "40%", float:"left"}} >
                <h3> Server avatar </h3>
                <img src={avatarUrl} alt="avatar" className="avatar" />
            </div>
            <div style={{width: "40%", float:"left"}} >
                <h3> Preview avatar </h3>
                <img src={avatarBody} alt="avatar" className="avatar"  />
            </div>
        </div>
    </div>)
}