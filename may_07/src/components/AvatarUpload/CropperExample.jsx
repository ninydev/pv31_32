import React, { useState } from 'react';
import { Cropper } from 'react-advanced-cropper';
import 'react-advanced-cropper/dist/style.css'
import './style.css'

export const CropperExample = () => {
    const [image, setImage] = useState(
        'https://images.unsplash.com/photo-1599140849279-1014532882fe?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1300&q=80',
    );

    const sendToServer = (e) => {
        e.preventDefault();
        const formData = new FormData();
        formData.append('file', image);

        fetch('http://localhost:3000/upload', {
            method: 'POST',
            body: formData,
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            setImage(data.url)
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
                setImage(reader.result);
            };
            reader.onerror = (error) => console.error('Error: ', error)
            reader.readAsDataURL(file);
        }
    }

    const onChange = (cropper) => {
        console.log(cropper.getCoordinates(), cropper.getCanvas());
    };

    return (
        <div className="cropper-container">
            <h2>Cropper Example</h2>
            <input type="file" onChange={uploadImage} />
            <button onClick={sendToServer}>Upload</button>
        <Cropper
            src={image}
            onChange={onChange}
            className={'cropper'}
        />
        </div>
    )
};