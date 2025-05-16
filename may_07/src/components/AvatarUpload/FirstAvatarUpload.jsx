import {useState} from "react";

export function FirstAvatarUpload() {

    const [avatarUrl, setAvatarUrl] = useState(null);

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

    return(<div>
        <h1>First Avatar Upload</h1>
        <p>Upload your first avatar here.</p>
        <form onSubmit={onSubmit} encType="multipart/form-data">
            <input type="file" accept="image/*" name="file" />
            <input type="submit" value="Upload" />
        </form>
        <div>
            <div width="50%">
                <h3> Server avatar </h3>
                <img src={avatarUrl} alt="avatar" width="100px" />
            </div>
        </div>
    </div>)
}