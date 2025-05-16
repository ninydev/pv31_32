
export function FirstAvatarUpload() {

    return(<div>
        <h1>First Avatar Upload</h1>
        <p>Upload your first avatar here.</p>
        <form action="http://localhost:3000/upload" method="post" encType="multipart/form-data">
            <input type="file" accept="image/*" name="file" />
            <input type="submit" value="Upload" />
        </form>
    </div>)
}