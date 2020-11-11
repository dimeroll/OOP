<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output
     method="html"></xsl:output>
<xsl:template match="/">
  <html>
    <body>
     <table border = "1">
      <TR>
        <th>FullName</th>
        <th>Faculty</th>
        <th>Department</th>
        <th>Education</th>
        <th>University</th>
        <th>EducationPeriod</th>
      </TR>
      <xsl:for-each select = "Employees/Employee">
       <tr>
         <td>
          <xsl:value-of select = "@FullName"/>
         </td>
         <td>
          <xsl:value-of select = "@Faculty"/>
         </td>
         <td>
          <xsl:value-of select = "@Department"/>
         </td>
         <td>
          <xsl:value-of select = "@Education"/>
         </td>
         <td>
          <xsl:value-of select = "@University"/>
         </td>
         <td>
          <xsl:value-of select = "@EducationPeriod"/>
         </td>
        </tr>
       </xsl:for-each>
     </table>
   </body>
  </html>
 </xsl:template>
</xsl:stylesheet>





